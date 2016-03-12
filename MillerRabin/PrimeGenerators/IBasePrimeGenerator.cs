using System;
using System.Numerics;

namespace MillerRabin.PrimeGenerators
{
    public interface IBasePrimeGenerator
    {
        Func<BigInteger, BigInteger, BigInteger> RandomInteger { get; set; }
        Func<BigInteger, BigInteger, BigInteger> Power { get; set; }
    }
}
