using Service.Implementation;

namespace Service.Interface
{
    public interface ICarManufacturer
    {
        Car Car { get; set; }

        void CreateCar(IConfiguration configuration);
    }
}