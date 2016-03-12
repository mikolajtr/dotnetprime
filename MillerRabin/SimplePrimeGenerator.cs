using System;
using System.Numerics;

namespace MillerRabin
{
    public class SimplePrimeGenerator : IPrimeGenerator
    {
        public SimplePrimeGenerator()
        {
            RandomInteger = (min, max) =>
            {
                // using snippet from http://stackoverflow.com/questions/17357760/how-can-i-generate-a-random-biginteger-within-a-certain-range
                var random = new Random();
                byte[] bytes = max.ToByteArray();

                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= 0x7F; //force sign bit to positive
                var value = new BigInteger(bytes);
                var result = (value % min) + (max - min);

                return result;
            };

            //RandomInteger = (min, max) =>
            //{
            //    var random = new Random();
            //    return random.Next((int) min, (int) max);
            //};

            Power = (x, n) =>
            {
                if (n == 0)
                {
                    return 1;
                }

                if (n % 2 == 1)
                {
                    return x*Power(x, n - 1);
                }
                var a = Power(x, n/2);
                return a * a;
            };
        }

        public Func<BigInteger, BigInteger, BigInteger> RandomInteger { get; set; }

        public Func<BigInteger, BigInteger, BigInteger> Power { get; set; }

        public BigInteger GeneratePrime(BigInteger min, BigInteger max, int k)
        {
            BigInteger result;

            do
            {
                result = RandomInteger(min, max);
            } while (!IsPrime(result, k));

            return result;
        }

        public bool IsPrime(BigInteger number, int k)
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
                BigInteger a = RandomInteger(1, n);

                if (Power(a, d) % number == 1)
                {
                    return true;
                }
                for (int j = 0; j < s; j++)
                {
                    if (Power(a, Power(2, j)*d) % number == number - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
