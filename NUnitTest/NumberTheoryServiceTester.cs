using System;
using NUnit.Framework;
using Service.Exceptions;
using Service.Implementation;
using Service.Interface;

namespace NUnitTest
{
    [TestFixture]
    public class NumberTheoryServiceTester
    {
        [TestCase(-1), TestCase(-2), TestCase(-3)]
        public void Should_ThrowException_WhenNegativeNumber(int num)
        {
            INumberTheoryService service = new NumberTheoryService();

            // Assert.Catch<T>() succeeds if thrown Exception is a derived exception from the specified Exception
            Assert.Catch<ArgumentOutOfRangeException>(() => service.IsOdd(num));
        }

        [TestCase(-1), TestCase(-2), TestCase(-3)]
        public void Should_ThrowExceptionWithProperMessage_WhenNegativeNumber(int num)
        {
            INumberTheoryService service = new NumberTheoryService();

            // Assert.Throws<T>() exactly matches what has been thrown
            var thrownException = Assert.Throws<OutOfRangeException>(() => service.IsOdd(num));
            StringAssert.Contains("Service can't process negative numbers", thrownException.Message);
        }

        [TestCase(1), TestCase(3), TestCase(5)]
        public void Should_ReturnTrue_WhenNumberIsOdd(int num)
        {
            INumberTheoryService service = new NumberTheoryService();

            Assert.IsTrue(service.IsOdd(num));
        }

        [TestCase(2), TestCase(4), TestCase(6)]
        public void Should_ReturnFalse_WhenNumberIsEven(int num)
        {
            INumberTheoryService service = new NumberTheoryService();

            Assert.IsFalse(service.IsOdd(num));
        }

        [Test, Ignore(reason: "Number theory hasn't implemented IsPrime functionality yet")]
        public void Should_ReturnTrue_WhenNumberIsPrime()
        {
            Assert.IsFalse(true);
        }
    }
}
