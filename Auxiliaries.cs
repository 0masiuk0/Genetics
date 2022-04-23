using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

		public static T[] Flatten2DArray<T>(T[,] input)
		{
			int n = input.GetLength(0);
			int m = input.GetLength(1);
			T[] output = new T[input.Length];

			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++)
					output[m * i + j] = input[i, j];

			return output;
		}

		static Random rnd2 = new Random();
		static object rndLock2 = new object();

		public static T2 RandomChoice<T2>(IList<T2> collection)
		{
			lock(rndLock2)
			{
				int choice = rnd2.Next(collection.Count);
				return collection[choice];
			}
		}
	}


}
