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
    }
}
