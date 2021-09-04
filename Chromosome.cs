using System;
using System.Linq;

namespace Genetics
{
	public class Chromosome
	{
		public static double carryoverPercent = 0.05;
		
		double[] descendancePart = new double[7];

		public Chromosome(Race race)
		{
			descendancePart[(int)race] = 1;
		}

		private Chromosome(double[] descendancePartPercent)
		{
			if (descendancePartPercent.Count() != 7) throw new Exception("wrong sized argument");
			this.descendancePart = descendancePartPercent;
		}

		private Chromosome(Chromosome copyOrigin) 
		{
			copyOrigin.descendancePart.CopyTo(this.descendancePart, 0);
		}

		public static Chromosome Meiosis(Chromosome basis, Chromosome crossoverIntruder)
		{
			double[] intrusion = new double[7];
			double intrusionSize = 0;
			Chromosome newChromosome = new Chromosome(basis);

			for (int i=0; i < 7; i++) 
			{
				intrusion[i] = crossoverIntruder.descendancePart[i] * carryoverPercent;
				intrusionSize += intrusion[i];				
			}

			double contrlSum = 0;
			double maxDesc = 0;
			int maxDescIndex = 0;


			for (int i = 0; i < 7; i++)
			{
				newChromosome.descendancePart[i] -= basis.descendancePart[i] * intrusionSize;
				newChromosome.descendancePart[i] += intrusion[i];
				contrlSum += newChromosome.descendancePart[i];
				if (newChromosome.descendancePart[i] > maxDesc)
				{
					maxDescIndex = i;
					maxDesc = newChromosome.descendancePart[i];
				}
			}


			double evenizer = 0;
			//Corrction
			if (contrlSum !=1)
			{
				evenizer = 1 - contrlSum;
				newChromosome.descendancePart[maxDescIndex] += evenizer;
			}

			//DEBUG
			if (newChromosome.descendancePart.Sum() - 1 >= 0.000001) throw new Exception("Mutant!");

			return newChromosome;			
		}

		public double GetDescendancePercent(Race race)
		{
			return descendancePart[(int)race];
		}
	}
}