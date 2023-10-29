using Microsoft.AspNetCore.Mvc;

using RSMotors.Core.Interfaces;
using RSMotors.Web.ViewModel.Customer;

namespace RSMotors.Web.Controllers
{
    public class CustomerController : BaseController
	{
		private readonly ICustomerServices customerServices;

		public CustomerController(ICustomerServices customerServices)
		{
			this.customerServices = customerServices;
		}

		[HttpGet]
		public IActionResult AddCustomer()
		{
			var model = new AddCustomerViewModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddCustomer(AddCustomerViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await customerServices.AddCustomer(model);

			return RedirectToAction("AddCar", "Car");
		}

		[HttpGet]
		public async Task<IActionResult> AllCustomers()
		{
			List<CustomersViewModel> customers = await customerServices.AllCustomers();
			return View(customers);
		}
	}
}
