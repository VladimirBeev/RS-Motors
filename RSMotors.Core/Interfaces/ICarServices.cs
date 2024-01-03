using RSMotors.Web.ViewModel.Car;
using RSMotors.Web.ViewModel.Customer;

namespace RSMotors.Core.Interfaces
{
    public interface ICarServices
	{
		Task AddCar(AddCarViewModel addCar);
		Task<List<CustomerAllCarsViewModel>> CustomerCars(Guid customerId);
        Task<bool> DeleteCar(Guid id);
        Task<bool> EditCar(EditCarViewModel editCustomerViewModel);
        Task<DetailsCarViewModel?> GetCarDetails(Guid id);
        Task<EditCarViewModel?> GetCarForEdit(Guid id);
    }
}
