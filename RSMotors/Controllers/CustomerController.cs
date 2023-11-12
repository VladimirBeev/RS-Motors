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

			return RedirectToAction("Index","Home");
		}

		[HttpGet]
		public async Task<IActionResult> AllCustomers()
		{
			List<AllCustomersViewModel> customers = await customerServices.AllCustomers();
			return View(customers);
		}

		[HttpGet]
		public async Task<IActionResult> DetailsCustomer(Guid id)
		{
			CustomerViewModel customer = await customerServices.GetCustomer(id);
			return View(customer);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
            EditCustomerViewModel editCustomer = await customerServices.GetCustomerForEdit(id);

			return View(editCustomer);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit([Bind(include: "Id, FirstName")]EditCustomerViewModel editCustomerViewModel)
		{
			if (ModelState.IsValid)
			{
                bool editCustomer = await customerServices.EditCustomer(editCustomerViewModel);
				if (editCustomer)
				{
                    return RedirectToAction("AllCustomers");
                }
            }

            return RedirectToAction("AllCustomers");
        }

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
            EditCustomerViewModel editCustomer = await customerServices.GetCustomerForEdit(id);

            return View(editCustomer);
        }

		[HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
			bool customerDelete = await customerServices.DeleteCustomer(id);

			return RedirectToAction("AllCustomers");
        }
    }
}
