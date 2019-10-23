using NUnit.Framework;
using Service.Implementation;
using Service.Interface;

namespace NUnitTest
{
    [TestFixture]
    public class MemoryCalculatorTester
    {
        [Test]
        public void Should_Return_Zero_As_DefaultValue()
        {
            IMemoryCalculator memoryCalculator = new MemoryCalculator();

            Assert.AreEqual(0, memoryCalculator.Value);
        }

        [TestCase(11, 5, 6), TestCase(11, -12, 23)]
        public void Should_Return_Summation(int expectedSum, int a, int b)
        {
            IMemoryCalculator memoryCalculator = new MemoryCalculator();

            memoryCalculator.Add(a);
            memoryCalculator.Add(b);

            Assert.AreEqual(expectedSum, memoryCalculator.Value);
        }
    }
}
