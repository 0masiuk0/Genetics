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

		public static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
		{
			// TODO: Validation and special-casing for arrays.Count == 0
			int minorLength = arrays[0].Length;
			T[,] ret = new T[arrays.Count, minorLength];
			for (int i = 0; i < arrays.Count; i++)
			{
				var array = arrays[i];
				if (array.Length != minorLength)
				{
					throw new ArgumentException
						("All arrays must be the same length");
				}
				for (int j = 0; j < minorLength; j++)
				{
					ret[i, j] = array[j];
				}
			}
			return ret;
		}
	}


}
