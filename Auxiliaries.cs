using System;
using System.Collections.Generic;
using System.Text;

namespace Genetics
{
    public static class Auxiliaries
	{
        static readonly Random rnd = new Random();
        static readonly object rndLock = new object();

        public static ulong GetRandomUlong(ulong maxValue)
        {
			ulong result;

			byte[] resultBytes = new byte[8];

			lock (rndLock)
			{
				do
				{
					rnd.NextBytes(resultBytes);
					result = (ulong)BitConverter.ToInt64(resultBytes, 0);
				} while (result > ulong.MaxValue - ((ulong.MaxValue % maxValue) + 1) % maxValue);
			}

			return result % maxValue;
		}

		public static double dotProduct(double[] vect_A, double[] vect_B)
		{
			int n_a = vect_A.Length;
			int n_b = vect_B.Length;
			int n;

			if (n_a == n_b)
				n = n_a;
			else
				throw new Exception("Вектора разной размерности для скалярного умножения");

			double product = 0;
						
			for (int i = 0; i < n; i++)
				product += vect_A[i] * vect_B[i];

			return product;
		}
	}
}
