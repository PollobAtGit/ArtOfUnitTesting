using NUnit.Framework;
using NUnitTest.Fakes;
using Service.Interface;

namespace NUnitTest
{
    [TestFixture]
    public class CarManufacturerTester
    {
        [Test]
        public void Should_Return_Non_Null_Car_Object_If_Configuration_Is_Valid()
        {
            ICarManufacturer carManufacturer = new StubCarManufacturer(true);

            carManufacturer.CreateCar(null);

            Assert.IsNotNull(carManufacturer.Car);
        }

        [Test]
        public void Should_Return_Null_If_Configuration_Is_Not_Valid()
        {
            ICarManufacturer carManufacturer = new StubCarManufacturer(false);

            carManufacturer.CreateCar(null);

            Assert.IsNull(carManufacturer.Car);
        }
    }
}
