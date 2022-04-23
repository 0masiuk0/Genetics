﻿#define ParallelComputation

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace Genetics
{
	public class Population
	{

		public Person[] Dudes;
		public long DudesCount { get; private set; }
		public Person[] Chicks;
		public long ChicksCount { get; private set; }
		public long PeopleCount => DudesCount + ChicksCount;
		public int GenerationNumber { get; private set; }
		public double GenderRatio { get; private set; }		

		private Person[] NextGeneration;
		private long nextGenDudesCount = 0;
		private long nextGenChicksCount = 0;

		private GenerationsGenerationProgressReport progressReport;

		//TODO: validation of input
		public static double BirthRate  { get; set; }
		public static int GroomSearchRadius { get; set; }
		public static int GroomCount { get; set; }
		public static double racialPurityImportanceDepretiationCoef { get; set; }

		public static Random rnd = new Random();
		private object populationLock = new object();

		static Population()
		{
			BirthRate = 1.1;
			GroomSearchRadius = 250;
			GroomCount = 50;
			racialPurityImportanceDepretiationCoef = 1;
		}
				
		public Population(int[] SeedPersonCount)
		{
			if (SeedPersonCount.Length != 7) throw new Exception("Invalid races count");
			long PopulationCount = 0;
			foreach(int s in SeedPersonCount)
			{
				PopulationCount += s;
			}

			NextGeneration = new Person[PopulationCount];
			bool gender = true;
			int counter=0;

			for(int i=0; i<7; i++)
			{
				for (int j = 0; j < SeedPersonCount[i]; j++)
				{
					NextGeneration[counter++] = new Person((Race)i, gender);
					if (gender) nextGenChicksCount++; else nextGenDudesCount++;
					gender = !gender;										
				}
			}

			AdvanceGeneration();
		}

		public Population(Person[] people)
		{
			NextGeneration = people;
			nextGenChicksCount = (from p in people where p.IsWoman select p).Count();
			nextGenDudesCount = people.Count() - nextGenChicksCount;
			AdvanceGeneration();
		}

		int nextGenerationCount;

		private void MakeNewGeneration(System.ComponentModel.BackgroundWorker backgroundWorker)
		{
			
			progressReport.reproductionProgress = 0;
			thisGenerationBirthProgress = 0;

			lock (populationLock)
			{
				nextGenerationCount = (int)Math.Ceiling(PeopleCount * BirthRate);
				NextGeneration = new Person[nextGenerationCount];

				this.backgroundWorker = backgroundWorker;
				MotherIndex = 0;

#if ParallelComputation
				Parallel.For(0, nextGenerationCount, DeliverBaby);
#else
				for (int i = 0; i < nextGenerationCount; i++)
					DeliverBaby(i);
				
#endif

				AdvanceGeneration();

				Person.RacialPurityImportnace *= racialPurityImportanceDepretiationCoef;
			}
			progressReport.reproductionProgress = 100;
		}

		int MotherIndex = 0;
		int thisGenerationBirthProgress;
		readonly object MommyLock = new object();
		readonly object CounterLock = new object();
		System.ComponentModel.BackgroundWorker backgroundWorker;

		void DeliverBaby(int i)
		{
			int chosenMommyindex;
			lock (MommyLock)
			{
				//mother index is circled around Chicks array here. "i" is number of baby being delivered, used for progress check.
				chosenMommyindex = MotherIndex;
				MotherIndex++;
				if (MotherIndex == ChicksCount) MotherIndex = 0;
				thisGenerationBirthProgress++;
			}
			Person mommy = Chicks[chosenMommyindex];
			List<Person> daddyCandidates = ChooseMalePartnerCandidatesFor(chosenMommyindex);
			Person daddy = mommy.ChooseMalePartnerFrom(daddyCandidates);
			NextGeneration[i] = mommy.ConcieveFrom(daddy);

			int progress;
			lock (CounterLock)
			{
				if (NextGeneration[i].IsWoman) nextGenChicksCount++; else nextGenDudesCount++;				
			}

			progress = (int)Math.Round((thisGenerationBirthProgress) / (nextGenerationCount / 100.0));

			if (progressReport.reproductionProgress < progress || progressReport.generationNumber != this.GenerationNumber)
			{
				progressReport.reproductionProgress = progress;
				backgroundWorker.ReportProgress(progressReport.generationProgress, progressReport);
			}
			
		}

		private void AdvanceGeneration()
		{
			long DudeCounter = 0;
			long ChickCounter = 0;

			Dudes = new Person[nextGenDudesCount];
			Chicks = new Person[nextGenChicksCount];

			foreach (Person p in NextGeneration)
			{
				if (p.IsWoman)
					Chicks[ChickCounter++] = p;
				else
					Dudes[DudeCounter++] = p;
			}

			DudesCount = DudeCounter;
			ChicksCount = ChickCounter;
			GenderRatio = (double)DudesCount / (double)ChicksCount;

			NextGeneration = null;
			nextGenChicksCount = nextGenDudesCount = 0;

			GenerationNumber++;
		}

		private List<Person> ChooseMalePartnerCandidatesFor(long motherIndex)
		{
			long centralDudeIndex = (long)Math.Floor(motherIndex * GenderRatio);
			ulong startIndex = (ulong)Math.Max(centralDudeIndex - GroomSearchRadius, 0);
			ulong stopIndex = (ulong)Math.Min(centralDudeIndex + GroomSearchRadius, DudesCount);
			int candidatesCount = (int)(stopIndex - startIndex);
			List<Person> selectedCandidates = new List<Person>((int)(stopIndex-startIndex));

			for(ulong i = startIndex; i<stopIndex; i++)
			{
				selectedCandidates.Add(Dudes[i]);
			}

			int LooserDudesCount = candidatesCount - GroomCount;
			if (LooserDudesCount < 0) LooserDudesCount = 0;
			ulong looserIndex;

			for(int i=0; i < LooserDudesCount; i++)
			{
				looserIndex = (ulong)rnd.Next(candidatesCount);
				selectedCandidates.Remove(selectedCandidates[(int)looserIndex]);
				candidatesCount--;
			}

			return selectedCandidates;
		}

		public void MakeNewGenerations(int N, System.ComponentModel.BackgroundWorker backWrkr)
		{
			progressReport = new GenerationsGenerationProgressReport();

			for (int i=0;i<N;i++)
			{
				MakeNewGeneration(backWrkr);
				progressReport.generationProgress = 100 * (i + 1) / N;
				progressReport.generationNumber = GenerationNumber;
				progressReport.peopleCount = PeopleCount;
				backWrkr.ReportProgress(progressReport.generationProgress, progressReport);
			}
		}
				
		public int[] GetRacialPurityDeciles(out long personCount)
		{
			int[] racialPurityDeciles = new int[10];
			IEnumerable<double> racialPurities;
			Histogram racialPurityHistogram;
							
			lock (populationLock)
			{
				racialPurities = from person in Chicks.Concat(Dudes) select person.GetRacialPurity();
				racialPurityHistogram = new Histogram(racialPurities, 10, 0.0, 1.0);

				personCount = PeopleCount;

				for (int i = 0; i < 10; i++)
				{
					racialPurityDeciles[i] = (int)racialPurityHistogram[i].Count;
				}
			}				

			return racialPurityDeciles;
		}

		public struct GenerationsGenerationProgressReport
		{
			public int generationProgress;
			public int reproductionProgress;
			public int generationNumber;
			public long peopleCount;

			public GenerationsGenerationProgressReport(int generationProgress, int reproductionProgress,
				int generationNumber, long peopleCount)
			{
				this.generationProgress = generationProgress;
				this.reproductionProgress = reproductionProgress;
				this.generationNumber = generationNumber;
				this.peopleCount = peopleCount;
			}

			public GenerationsGenerationProgressReport(Population pop)
			{
				this.generationProgress = 0;
				this.reproductionProgress = 0;
				this.generationNumber = pop.GenerationNumber;
				this.peopleCount = pop.PeopleCount;
			}
		}
	}
}
