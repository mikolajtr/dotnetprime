using System;
using System.Numerics;

namespace MillerRabin
{
    public interface IPrimeGenerator : IBasePrimeGenerator
    {
        BigInteger GeneratePrime(BigInteger min, BigInteger max, int k);
        bool IsPrime(BigInteger number, int k);
    }
}