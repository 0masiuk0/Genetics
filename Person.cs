using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace Genetics
{
	public class Person
	{
		//max stDev = 0.378
		static double _racialPurityImportance = 0.95;
		public static double RacialPurityImportnace
		{
			get
			{ return _racialPurityImportance; }
			set
			{
				if (value >= 1) _racialPurityImportance = 1;
				else
					if (value <= 0) _racialPurityImportance = 0;
				else
					_racialPurityImportance = value;
			}
		}
				
		static readonly double StdDevToPercentCoef = 1 / ArrayStatistics.StandardDeviation(new int[7] { 0, 0, 0, 0, 0, 0, 1 });

		public bool IsWoman { get; private set; }

		//DEBUG access modificator public, release shall be "protected"
		/* protected*/ public Chromosome[,] chromosomes = new Chromosome[2, 23];
		static readonly Race[] possibleRaces = new Race[7] {Race.Moiran, Race.Julian, Race.Aivian, Race.Feklite,
			Race.Camelite, Race.Dynian, Race.Aidian};

		public Person(Race race)
		{
			lock (randomGeneratorGenderLock1)
			{
				IsWoman = randomGeneratorGender.Next(0, 2) == 0;
			}
			GenPureRace(race);
			
		}

		public Person(Race race, bool IsWoman)
		{
			this.IsWoman = IsWoman;
			GenPureRace(race);
		}

		private Person(Person mother, Person father)
		{
			lock (randomGeneratorGenderLock1)
			{
				IsWoman = randomGeneratorGender.Next(0, 2) == 0;
			}
			chromosomes[0, 0] = IsWoman ? father.chromosomes[0, 0] : father.chromosomes[1, 0];

			bool chosenXChromosome;
			lock (chromosomeChooserRandomGeneratorLock)
			{
				chosenXChromosome = chromosomeChooserRaandomGenerator.Next(0, 2) == 0;
			}
			chromosomes[1, 0] = chosenXChromosome ? mother.chromosomes[0, 0] : mother.chromosomes[1, 0];

			for (int i = 1; i < 23; i++)
			{
				chromosomes[0, i] = GetRandomGaploidChromosome(father, i);
				chromosomes[1, i] = GetRandomGaploidChromosome(mother, i);
			}
		}			

		//unit tests mock geeration constructor
		public Person(Chromosome[,] chromosomes, bool IsWoman)
		{
			if (chromosomes.GetLength(0) != 2 && chromosomes.GetLength(1) != 23) throw new Exception("Mutant!!!");

			this.chromosomes = chromosomes;
			this.IsWoman = IsWoman;
		}

		Chromosome GetRandomGaploidChromosome(Person parent, int pairNumber)
		{
			bool chosenHomologicChromosome = false;
			lock (chromosomeChooserRandomGeneratorLock)
			{
				chosenHomologicChromosome = chromosomeChooserRaandomGenerator.Next(0, 2) == 0;
			}
			return
				chosenHomologicChromosome ?
				Chromosome.Meiosis(parent.chromosomes[0, pairNumber], parent.chromosomes[1, pairNumber])
				:
				Chromosome.Meiosis(parent.chromosomes[1, pairNumber], parent.chromosomes[0, pairNumber]);
			
		}

		bool descCalcDone = false;
		double[] descendancePartPercent = new double[7];

		public double[] GetDescendance()
		{
			if (!descCalcDone)
				CalcDescendance();
			descCalcDone = true;
			return descendancePartPercent;
		}
		
		public double GetDescendanceOfRace(Race race)
		{
			if (!descCalcDone)
				CalcDescendance();
			descCalcDone = true;
			return descendancePartPercent[(int)race];
		}

		private void CalcDescendance()
		{
			foreach (Chromosome ch in chromosomes)
			{
				foreach (Race r in possibleRaces)
				{
					descendancePartPercent[(int)r] += ch.GetDescendancePercent(r);
				}				
			}

			for (int i = 0; i < 7; i++)
			{
				descendancePartPercent[i] /= 46;
			}
		}

		void GenPureRace(Race race)
		{
			for (int i = 0; i < 2; i++)
				for (int j = 0; j < 23; j++)
					chromosomes[i, j] = new Chromosome(race);
		}

		public Person ChooseMalePartnerFrom(List<Person> candidates)
		{
			if (!IsWoman) throw new Exception("No gayness allowed");
			
			Dictionary<ulong, Person> attractivnessKeyedCandidates = GetAttractinessKeyedCandidates(candidates, out ulong maxKey);

			ulong winningPoint = Auxiliaries.GetRandomUlong(maxKey + 1);			

			var en = candidates.GetEnumerator();
			en.MoveNext();
			Person groom = en.Current;

			Dictionary<ulong, Person>.Enumerator candidatesEnumerator2 = attractivnessKeyedCandidates.GetEnumerator();

			while (candidatesEnumerator2.MoveNext() && candidatesEnumerator2.Current.Key <= winningPoint)
			{
				groom = candidatesEnumerator2.Current.Value;
			}

			return groom;
		}

		/*DEBUG Release modifier private*/
		public Dictionary<ulong, Person> GetAttractinessKeyedCandidates(List<Person> candidates, out ulong lastKey)
		{
			ulong roulletSectorMarker;
			
			Dictionary<ulong, Person> attractivnessKeyedCandidates;
			
			attractivnessKeyedCandidates = new Dictionary<ulong, Person>();
			List<Person>.Enumerator candidatesEnumerator = candidates.GetEnumerator();

			roulletSectorMarker = 0;
			candidatesEnumerator.MoveNext();
			Person candidate = candidatesEnumerator.Current;
			if (candidate == null) throw new Exception("no groom candidates found");
			double attractiveness = Person.CalculateMutualAttractionCoefficient(this, candidate);
			if (attractiveness >= (1 / 10000))
			{
				uint attractivenessPercent = (uint)Math.Round(attractiveness * 10000);
				roulletSectorMarker += attractivenessPercent;
				attractivnessKeyedCandidates.Add(roulletSectorMarker, candidate);
			}


			while (candidatesEnumerator.MoveNext())
			{
				candidate = candidatesEnumerator.Current;
				attractiveness = Person.CalculateMutualAttractionCoefficient(this, candidate);
				if (attractiveness > (1 / 10000))
				{
					uint attractivenessPercent = (uint)Math.Round(attractiveness * 10000);
					roulletSectorMarker += attractivenessPercent;
					attractivnessKeyedCandidates.Add(roulletSectorMarker, candidate);
				}
			}

			if (roulletSectorMarker == 0) throw new Exception("no groooms found");

			lastKey = roulletSectorMarker;

			return attractivnessKeyedCandidates;
		}

		public Person ConcieveFrom(Person father)
		{
			if (!this.IsWoman&&father.IsWoman) throw new Exception("generally male do not give birth and women cannot be fathers");

			return new Person(this, father);
		}
				
		public double GetRacialPurity()
		{
			double stDev = ArrayStatistics.StandardDeviation(GetDescendance());
			double racialPurity = stDev * StdDevToPercentCoef;
			return Math.Max(0, Math.Min(1, racialPurity));
		}

		static double GetRacialProximity(Person chick, Person dude)
		{
			double[] ChickDescendance = chick.GetDescendance();
			double[] DudesDescendance = dude.GetDescendance();
			double PseudoCorrelation = 0;

			for (int i=0; i < 7; i++)
			{
				PseudoCorrelation += Math.Min(ChickDescendance[i], DudesDescendance[i]);
			}

			return PseudoCorrelation;
		}

		public static double CalculateMutualAttractionCoefficient(Person chick, Person dude)
		{
			double ChickAttractionToDude, DudeAttractionToChick;

			double ChickRacialPurity = chick.GetRacialPurity();
			double DudeRacialPurity = dude.GetRacialPurity();
			double RacialProximity = GetRacialProximity(chick, dude);

			ChickAttractionToDude = 1 - _racialPurityImportance * ChickRacialPurity + _racialPurityImportance * ChickRacialPurity * RacialProximity;
			DudeAttractionToChick = 1 - _racialPurityImportance * DudeRacialPurity + _racialPurityImportance * DudeRacialPurity * RacialProximity;

			return ChickAttractionToDude * DudeAttractionToChick;
		}
		
	

		readonly static Random randomGeneratorGender = new Random();
		static readonly object randomGeneratorGenderLock1 = new object();
		readonly static Random chromosomeChooserRaandomGenerator = new Random();
		static readonly object chromosomeChooserRandomGeneratorLock = new object();		
	}

	public enum Race { Moiran = 0, Julian = 1, Aivian = 2, Feklite = 3, Camelite = 4, Dynian = 5, Aidian = 6 }
}