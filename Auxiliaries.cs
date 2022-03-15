using System;
using System.Collections.Generic;
using System.Text;

namespace Genetics
{
    public static class Auxiliaries
	{
        static Random rnd = new Random();
        static object rndLock = new object();

        public static ulong GetRandomUlong(ulong maxValue)
        {   
            //This algorithm works with inclusive upper bound, but random generators traditionally have exclusive upper bound, so we adjust.
            //Zero is allowed, function will return zero, as well as for 1. Same behavior as System.Random.Next().
            if (maxValue > 0) maxValue--;

            byte[] maxValueBytes = BitConverter.GetBytes(maxValue);
            byte[] result = new byte[8];

            int i;

            lock (rndLock)
            {
                for (i = 7; i >= 0; i--)
                {
                    //senior bytes are either zero (then Random will write in zero without our help), or equal or below that of maxValue
                    result[i] = (byte)rnd.Next(maxValueBytes[i] + 1);

                    //If, going high bytes to low bytes, we got ourselves a byte, that is lower than that of MaxValue, then lower bytes may be of any value.
                    if ((uint)result[i] < maxValueBytes[i]) break;
                }

                for (i--; i >= 0; i--) // I like this row
                {
                    result[i] = (byte)rnd.Next(256);
                }
            }

            return BitConverter.ToUInt64(result, 0);
        }
    }
}
