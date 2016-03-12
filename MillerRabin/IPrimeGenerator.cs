using System;
using System.Numerics;

namespace MillerRabin
{
    public interface IPrimeGenerator
    {
        Func<BigInteger, BigInteger, BigInteger> RandomInteger { get; set; }
        Func<BigInteger, BigInteger, BigInteger> Power { get; set; } 
        BigInteger GeneratePrime(BigInteger min, BigInteger max, int k);
        bool IsPrime(BigInteger number, int k);
    }
}