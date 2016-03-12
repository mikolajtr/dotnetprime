using System;
using System.Numerics;

namespace MillerRabin.Helpers
{
    public static class PrimeGeneratorHelpers
    {
        public static BigInteger GenerateRandomBigInteger(BigInteger min, BigInteger max)
        {
            // using snippet from http://stackoverflow.com/questions/17357760/how-can-i-generate-a-random-biginteger-within-a-certain-range
            var random = new Random();
            byte[] bytes = max.ToByteArray();

            random.NextBytes(bytes);
            bytes[bytes.Length - 1] &= 0x7F; //force sign bit to positive
            var value = new BigInteger(bytes);
            var result = (value % min) + (max - min);

            return result;
        }

        public static BigInteger ExponentBySquaring(BigInteger x, BigInteger n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n % 2 == 1)
            {
                return x * ExponentBySquaring(x, n - 1);
            }
            var a = ExponentBySquaring(x, n / 2);
            return a * a;
        }
    }
}
