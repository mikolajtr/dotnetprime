using System.Numerics;

namespace MillerRabin.PrimeGenerators
{
    public interface IPrimeGenerator : IBasePrimeGenerator
    {
        BigInteger GeneratePrime(BigInteger min, BigInteger max, int k);
        bool IsPrime(BigInteger number, int k);
    }
}