using System;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Genetics
{
	//TESTED	
	public class Chromosome
	{
		public static double carryoverPercent = 0.05;

		double[] descendancePart = new double[7];

		public Chromosome(Race race)
		{
			descendancePart[(int)race] = 1;
		}

		public Chromosome(double[] descendancePartPercent)
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


			for (int i = 0; i < 7; i++)
			{
				intrusion[i] = Math.Round(crossoverIntruder.descendancePart[i] * carryoverPercent, 5);
				intrusionSize += intrusion[i];
			}

			double contrlSum = 0;
			double maxDesc = 0;
			int maxDescIndex = 0;
			Chromosome newChromosome = new Chromosome(basis);


			for (int i = 0; i < 7; i++)
			{
				newChromosome.descendancePart[i] -= Math.Round(basis.descendancePart[i] * intrusionSize, 5);
				newChromosome.descendancePart[i] += intrusion[i];
				contrlSum += newChromosome.descendancePart[i];
				if (newChromosome.descendancePart[i] > maxDesc)
				{
					maxDescIndex = i;
					maxDesc = newChromosome.descendancePart[i];
				}
			}


			double evenizer;

			//Correction
			if (contrlSum != 1)
			{
				evenizer = 1 - contrlSum;
				newChromosome.descendancePart[maxDescIndex] += evenizer;
			}

			return newChromosome;
		}

		public double GetDescendancePercent(Race race)
		{
			return descendancePart[(int)race];
		}

		public override string ToString()		
		{
			string s = "";
			foreach (double d in descendancePart)
				s += d.ToString() + ", ";
			return s.Substring(0, s.Length- 2);
		}

	
		
	}
}
