using RSMotors.Web.ViewModel.Car;

namespace RSMotors.Core.Interfaces
{
    public interface ICarServices
	{
		Task AddCar(AddCarViewModel addCar);
		Task<List<AddCarViewModel>> CustomerCars(Guid customerId);
	}
}
