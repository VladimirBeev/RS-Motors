﻿using Microsoft.EntityFrameworkCore;

using RSMotors.Core.Interfaces;
using RSMotors.Infrastructure;
using RSMotors.Infrastructure.Models;
using RSMotors.Web.ViewModel.Car;
using RSMotors.Web.ViewModel.Customer;

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

        public async Task<List<CustomerAllCarsViewModel>> CustomerCars(Guid customerId)
        {
            return await context.Cars
                .Select(c => new CustomerAllCarsViewModel()
                {
                    Id = c.Id,
                    Manufacturer = c.Manufacturer,
                    Model = c.Model,
                    Year = c.Year,
                    Vin = c.Vin,
                    RegistrationPlate = c.RegistrationPlate,
                    Details = c.Details,
                    CustomerId = c.CustomerId
                })
                .Where(c => c.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<bool> DeleteCar(Guid id)
        {
            Car? car = await context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car != null)
            {
                context.Cars.Remove(car);

                await context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> EditCar(EditCarViewModel editCarViewModel)
        {
            Car? car = await context.Cars.FirstOrDefaultAsync(cu => cu.Id == editCarViewModel.Id);

            if (car != null)
            {
                car.Id = editCarViewModel.Id;
                car.Manufacturer = editCarViewModel.Manufacturer;
                car.Model = editCarViewModel.Model;
                car.Year = editCarViewModel.Year; 
                car.Vin = editCarViewModel.Vin;
                car.RegistrationPlate = editCarViewModel.RegistrationPlate;
                car.Details = editCarViewModel.Details;
                car.CustomerId = editCarViewModel.CustomerId;

                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<DetailsCarViewModel?> GetCarDetails(Guid id)
        {
            Car? car = await context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (car != null)
            {
                DetailsCarViewModel detailsCarView = new DetailsCarViewModel()
                {
                    Id = car.Id,
                    Manufacturer = car.Manufacturer,
                    Model = car.Model,
                    Year = car.Year,
                    Vin = car.Vin,
                    RegistrationPlate = car.RegistrationPlate,
                    Details = car.Details,
                    CustomerId = car.CustomerId
                };

                return detailsCarView;
            }

            return null;
        }

        public async Task<EditCarViewModel?> GetCarForEdit(Guid id)
        {
            Car? car = await context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (car != null)
            {
                EditCarViewModel editCar = new EditCarViewModel()
                {
                    Id = car.Id,
                    Manufacturer = car.Manufacturer,
                    Model = car.Model,
                    Year = car.Year,
                    Vin = car.Vin,
                    RegistrationPlate = car.RegistrationPlate,
                    Details = car.Details,
                    CustomerId = car.CustomerId
                };

                return editCar;
            }

            return null;
        }
    }
}
