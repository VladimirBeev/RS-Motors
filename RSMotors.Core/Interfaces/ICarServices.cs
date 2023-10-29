using RSMotors.Web.ViewModels;

namespace RSMotors.Core.Interfaces
{
	public interface ICarServices
	{
		Task AddCar(AddCarViewModel addCar);
	}
}
