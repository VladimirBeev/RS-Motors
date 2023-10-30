using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using RSMotors.Core.Interfaces;
using RSMotors.Infrastructure.Extensions;
using RSMotors.Web.ViewModel.Car;

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
            List<AddCarViewModel> cars = await carServices.CustomerCars(id);
            return View(cars);
        }

	}
}
