using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using RSMotors.Core.Interfaces;
using RSMotors.Core.Services;
using RSMotors.Infrastructure.Extensions;
using RSMotors.Web.ViewModel.Car;
using RSMotors.Web.ViewModel.Customer;

namespace RSMotors.Web.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarServices carServices;

        public CarController(ICarServices carServices)
        {
            this.carServices = carServices;
        }
        [HttpGet]
        public IActionResult AddCar(Guid id)
        {
            var model = new AddCarViewModel();
            model.CustomerId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarViewModel addCar)
        {
            if (!ModelState.IsValid)
            {
                return View(addCar);
            }


			await carServices.AddCar(addCar);

            return View("CarDetails");
        }

        [HttpGet]
        public async Task<IActionResult> CustomerCars(Guid id)
        {
            List<CustomerAllCarsViewModel> cars = await carServices.CustomerCars(id);
            return View(cars);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            EditCarViewModel? editCarView = await carServices.GetCarForEdit(id);

            return View(editCarView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCarViewModel editCarViewModel)
        {
            if (ModelState.IsValid)
            {
                bool editCar = await carServices.EditCar(editCarViewModel);
                if (editCar)
                {
                    return RedirectToAction("AllCustomers","Customer");
                }
            }

            return RedirectToAction("AllCustomers", "Customer");
        }

        [HttpGet]
        public async Task<JsonResult> Details(Guid id)
        {
            DetailsCarViewModel? car = await carServices.GetCarDetails(id);

            return new JsonResult(Ok(car));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            bool carDelete = await carServices.DeleteCar(id);

            if (carDelete == false)
            {
                return RedirectToAction("AllCustomers", "Customer");
            }

            return RedirectToAction("AllCustomers", "Customer");
        }

	}
}
