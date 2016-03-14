using System;
using System.Numerics;
using MillerRabin.Helpers;

namespace MillerRabin.PrimeGenerators
{
    public class PrimeGenerator : IPrimeGenerator
    {
        public PrimeGenerator()
        {
            RandomInteger = PrimeGeneratorHelpers.GenerateRandomBigInteger;

            Power = PrimeGeneratorHelpers.ExponentBySquaring;
        }

        public Func<BigInteger, BigInteger, BigInteger> RandomInteger { get; set; }

        public Func<BigInteger, BigInteger, BigInteger> Power { get; set; }

        public virtual BigInteger GeneratePrime(BigInteger min, BigInteger max, int k)
        {
            BigInteger result;

            do
            {
                result = RandomInteger(min, max);
            } while (!IsPrime(result, k));

            return result;
        }

        public virtual bool IsPrime(BigInteger number, int k)
        {
            if (number == 2 || number == 5)
            {
                return true;
            }

            if (number%2 == 0 || number%5 == 0)
            {
                return false;
            }

            BigInteger n = number - 1;
            BigInteger d = n;
            BigInteger s = 0;

            while (d%2 == 0)
            {
                d /= 2;
                s++;
            }

            for (int i = 0; i < k; i++)
            {
                if (!PrimalityTest(number, d, s))
                {
                    return false;
                }
            }
            return true;
        }

        private bool PrimalityTest(BigInteger number, BigInteger d, BigInteger s)
        {
            BigInteger a = RandomInteger(1, number - 1);

            if (Power(a, d) % number == 1)
            {
                return true;
            }
            for (int j = 0; j < s; j++)
            {
                if (Power(a, Power(2, j) * d) % number == number - 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
