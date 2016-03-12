using System;
using System.Numerics;

namespace MillerRabin
{
    public interface IBasePrimeGenerator
    {
        Func<BigInteger, BigInteger, BigInteger> RandomInteger { get; set; }
        Func<BigInteger, BigInteger, BigInteger> Power { get; set; }
    }
}
