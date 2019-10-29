using Service.Interface;

namespace Service.Implementation
{
    public class CarManufacturer : ICarManufacturer
    {
        public Car Car { get; set; }

        public void CreateCar(IConfiguration configuration)
        {
            if (IsValidConfiguration(configuration))
                Car = new Car();
        }

        protected virtual bool IsValidConfiguration(IConfiguration configuration) => configuration != null;
    }
}
