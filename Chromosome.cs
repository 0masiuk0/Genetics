using System;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Genetics
{
	//TESTED	
	public class Chromosome
	{
		public static double carryoverPercent = 0.01;

		readonly UnitVector7 _descendance ;

		public UnitVector7 Descendance
		{ get { return _descendance ; } }

		public Chromosome(Race race)
		{
			_descendance = UnitVector7.GetOrt((int)race);
		}

		public Chromosome(UnitVector7 descendance)
		{
			_descendance = descendance;
		}

		public Chromosome(double[] descendancePartPercent) : this(new UnitVector7(descendancePartPercent))
		{ }

		private Chromosome(Chromosome copyOrigin)
		{
			_descendance = copyOrigin.Descendance.Copy();
		}

		public static Chromosome Meiosis(Chromosome basis, Chromosome crossoverIntruder)
		{
			UnitVector7 newDescendance = UnitVector7.TurnAtoBandNormalize(basis.Descendance, crossoverIntruder.Descendance, carryoverPercent);
			return new Chromosome(newDescendance);
		}

		public double GetDescendancePercent(Race race)
		{
			return _descendance.ProjectionOnAxisScalar((int) race);
		}

		public override string ToString()		
		{
			string s = "";
			foreach (double d in _descendance.Components)
				s += d.ToString() + ", ";
			return s.Substring(0, s.Length- 2);
		}

	
		
	}
}
