using RSMotors.Web.ViewModel.Car;

namespace RSMotors.Core.Interfaces
{
    public interface ICarServices
	{
		Task AddCar(AddCarViewModel addCar);
		Task<List<CustomerAllCarsViewModel>> CustomerCars(Guid customerId);
        Task<bool> DeleteCar(Guid id);
        Task<DetailsCarViewModel?> GetCarDetails(Guid id);
    }
}
