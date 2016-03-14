using System.Numerics;
using MillerRabin.PrimeGenerators;
using NUnit.Framework;

namespace MillerRabin.Tests
{
    [TestFixture]
    public class PrimeGeneratorTests
    {
        private int _k;
        private int _n;
        private BigInteger _m;
        private int[] _primes;
        private IPrimeGenerator _generator;

        [SetUp]
        public void SetUp()
        {
            _k = 4;
            _n = 7;
            _m = 6561;
            _primes = new[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59};
            _generator = new PrimeGenerator();
        }

        [Test]
        public void CheckIntTest()
        {
            Assert.IsTrue(_generator.IsPrime(_n, _k));
        }

        [Test]
        public void CheckSeriesTest()
        {
            foreach (var prime in _primes)
            {
                Assert.IsTrue(_generator.IsPrime(prime, _k));
            }
        }

        [Test]
        public void CheckBigIntegerTest()
        {
            Assert.IsFalse(_generator.IsPrime(_m, _k));
        }
    }
}
