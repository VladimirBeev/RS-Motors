using Microsoft.EntityFrameworkCore;

using RSMotors.Core.Interfaces;
using RSMotors.Infrastructure;
using RSMotors.Infrastructure.Models;
using RSMotors.Web.ViewModels;

namespace RSMotors.Core.Services
{
    public class CarService : ICarServices
	{
		private readonly RSMotorsDbContext context;

		public CarService(RSMotorsDbContext context)
		{
			this.context = context;
		}

		public async Task AddCar(AddCarViewModel addCar)
		{
			Customer? customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == addCar.CustomerId);

			Car car = new Car();
			car.Manufacturer = addCar.Manufacturer;
			car.Model = addCar.Model;
			car.Year = addCar.Year;
			car.Vin = addCar.Vin;
			car.RegistrationPlate = addCar.RegistrationPlate;
			car.Details = addCar.Details;
			car.CustomerId = addCar.CustomerId;
			car.Customer = customer!;

			await context.Cars.AddAsync(car);

			await context.SaveChangesAsync();
		}
	}
}
