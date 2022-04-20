using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using System.Diagnostics.CodeAnalysis;

namespace Genetics
{
	public class Vector7 : IEquatable<Vector7>
	{
		protected double[] _components = new double[7];

		protected static readonly Vector7 CentralVector;
		protected static readonly double AxisToCentralVectorAngle;

		protected const double Pi = MathNet.Numerics.Constants.Pi;

		public double[] Components
		{
			get { return _components; }
		}

		protected Vector<double> ThisAsMathNetVector
		{
			get { return CreateVector.DenseOfArray<double>(_components); }
		}

		static Vector7()
		{
			double component = Math.Sqrt(1.0 / 7.0);
			double[] cvComp = new double[7];

			for (int i = 0; i < 7; i++)
				cvComp[i] = component;

			CentralVector = new Vector7(cvComp);
			AxisToCentralVectorAngle = GetAngle(CentralVector, new Vector7(new double[] {1, 0, 0, 0, 0, 0, 0 }));
		}

		protected Vector7() { }

		public Vector7(double[] components)
		{
			if (components.Length == 7)
				this._components = components;
			else
				throw new Exception("incorrect data for 7-vector");
		}

		public Vector7(IEnumerable<double> components)
		{
			if (components.Count() == 7)
				this._components = components.ToArray();
			else
				throw new Exception("incorrect data for 7-vector");
		}

		public double ProjectionOnAxisScalar(int a)
		{
			if (a < 0 || a > 6) throw new Exception("incorrect axis number");

			double[] ort = new double[7];
			ort[a] = 1;

			return DotProduct(this, new Vector7(ort));
		}

		public double AngleToCentralVectorNormalizedTo1()
		{
			double angleInRadians = GetAngle(this, CentralVector);
			return angleInRadians / AxisToCentralVectorAngle;
		}

		public Vector7 ProjectToAnotherVector(Vector7 projectTo)
		{
			return (DotProduct(this, projectTo) / DotProduct(projectTo, projectTo)) * projectTo;
		}

		public bool IsColinear(Vector7 b)
		{
			double coef = this.Components[0] / b.Components[0];
			for (int i = 1; i < 7; i++)
			{
				if (Math.Abs(coef - this.Components[i] / b.Components[i]) > 0.000000001)
					return false;
			}
			return true;
		}

		public UnitVector7 Normalize()
		{
			return new UnitVector7(this);
		}

		public Vector7 Copy()
		{
			return new Vector7(_components);
		}

		public override string ToString()
		{
			string s = "";
			foreach (double d in _components)
				s += d.ToString() + ", ";
			return '(' + s.Substring(0, s.Length - 2) + ')';
		}

		public bool Equals(Vector7 other)
		{
			if (other.GetType() != this.GetType()) return false;
			return this.Components.SequenceEqual(other.Components);
		}

		public static double DotProduct(Vector7 vect_A, Vector7 vect_B)
		{
			double product = 0;

			for (int i = 0; i < 7; i++)
				product += vect_A._components[i] * vect_B._components[i];

			return product;
		}

		public static double GetAngle(Vector7 vect_A, Vector7 vect_B)
		{
			return Math.Acos(DotProduct(vect_A, vect_B) / (vect_A.Length * vect_B.Length));
		}

		public static Vector7 SumVectors(IEnumerable<Vector7> vectors)
		{
			double[][] vectorCmps = (from cmp in vectors select cmp.Components).ToArray();
			double[] result = new double[7];
			foreach (double[] cmp in vectorCmps)
			{
				for (int i = 0; i < 7; i++)
				{
					result[i] += cmp[i];
				}
			}

			return new Vector7(result);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_components);
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType() != this.GetType()) return false;
			if (obj is Vector7)
				return this.Equals(obj as Vector7);
			else
				return false;
		}

		public static Vector7 operator +(Vector7 v1, Vector7 v2)
		{
			double[] newComponents = new double[7];

			for (int i=0; i < 7; i++)
			{
				newComponents[i] = v1.Components[i] + v2.Components[i];
			}

			return new Vector7(newComponents);
		}

		public static Vector7 operator -(Vector7 v1, Vector7 v2)
		{
			double[] newComponents = new double[7];

			for (int i = 0; i < 7; i++)
			{
				newComponents[i] = v1.Components[i] - v2.Components[i];
			}

			return new Vector7(newComponents);
		}

		public static Vector7 operator *(Vector7 v2, double x)
		{
			double[] newComponents = new double[7];

			for (int i = 0; i < 7; i++)
			{
				newComponents[i] = x * v2.Components[i];
			}

			return new Vector7(newComponents);
		}

		public static Vector7 operator *(double x, Vector7 v)
		{
			return v * x;
		}

		public static Vector7 operator /(Vector7 v2, double x)
		{
			double[] newComponents = new double[7];

			for (int i = 0; i < 7; i++)
			{
				newComponents[i] = v2.Components[i] / x;
			}

			return new Vector7(newComponents);
		}

		public static bool operator ==(Vector7 v1, Vector7 v2)
		{
			return (v1.Equals(v2));
		}

		public static bool operator !=(Vector7 v1, Vector7 v2)
		{
			return !(v1.Equals(v2));
		}

		public virtual double Length
		{
			get
			{
				double sumSq = 0;
				foreach(double c in _components)
				{
					sumSq += c * c;
				}
				return Math.Sqrt(sumSq);
			}
		}
	}

	public class UnitVector7 : Vector7
	{
		public UnitVector7(double[] components)
		{
			Vector7 v = new Vector7(components);
			double vLength = v.Length;
			var newComponents = from c in new List<double>(v.Components) select c / vLength;
			this._components = newComponents.ToArray();
		}

		public UnitVector7(Vector7 nonNormalizedVector) : this(nonNormalizedVector.Components)
		{ }

		private UnitVector7(int i)
		{
			if (i < 0 || i > 6)
				throw new ArgumentOutOfRangeException("bad axis number for ort generation");

			this._components[i] = 1.0;
		}
		
		public static UnitVector7 TurnAtoBandNormalize(Vector7 a, Vector7 b, double turningFraction)
		{
			if (turningFraction < 0 || turningFraction > 1.0) throw new ArgumentOutOfRangeException("turning fraction should be in [0, 1]");

			if (a.IsColinear(b)) return new UnitVector7(a);

			Vector7 projBtoA = b.ProjectToAnotherVector(a);
			Vector7 normalToA = b - projBtoA;
			UnitVector7 baseA = new UnitVector7(a);
			UnitVector7 baseB = new UnitVector7(normalToA);

			double angleFromA = GetAngle(a, b) * turningFraction;

			return new UnitVector7(baseA * Math.Cos(angleFromA) + baseB * Math.Sin(angleFromA));
		}
		
		public static explicit operator UnitVector7(Vector7 v)
		{
			return new UnitVector7(v);
		}

		public static double DotProduct(UnitVector7 vect_A, UnitVector7 vect_B)
		{
			if (vect_A == vect_B) 
				return 1.0;
			else
				return Vector7.DotProduct(vect_A, vect_B);
		}

		public static UnitVector7 GetOrt(int i)
		{
			return new UnitVector7(i);
		}

		public override double Length => 1.0;
	}
	
	public class Vector7Basis
	{
		Vector7[] basis = new Vector7[7];
		public Vector7[] Basis { get { return basis; } }

		Matrix<double> tranformationMatrix;
		Matrix<double> invertedTransformationMatrix;

		public Vector7Basis(Vector7[] basis)
		{
			if (basis.Length != 7)
				throw new Exception("bad basis");

			Array.Copy(basis, this.basis, 7);
			var transMatrixColumns = from basicVector in basis select basicVector.Components;
			tranformationMatrix = CreateMatrix.DenseOfColumnArrays<double>(transMatrixColumns);
			invertedTransformationMatrix = tranformationMatrix.Inverse();
		}

		public Vector7 SwitchToThisBasis(Vector7 inputVector)
		{ 	
			var inputVectorAsVector = CreateVector.DenseOfArray(inputVector.Components);
			var newVector = invertedTransformationMatrix.Multiply(inputVectorAsVector);
			return new Vector7(newVector.ToArray());
		}

		public Vector7 SwitchBackFromThisBasis(Vector7 inputVector)
		{
			var inputVectorAsVector = CreateVector.DenseOfArray(inputVector.Components);
			var newVector = tranformationMatrix.Multiply(inputVectorAsVector);
			return new Vector7(newVector.ToArray());
		}

		
	}
}

	

