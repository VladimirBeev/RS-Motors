using Microsoft.EntityFrameworkCore;

using RSMotors.Core.Interfaces;
using RSMotors.Infrastructure;
using RSMotors.Infrastructure.Models;
using RSMotors.Web.ViewModel.Customer;

namespace RSMotors.Core.Services
{
    public class CustomerService : ICustomerServices
	{
		private readonly RSMotorsDbContext context;

		public CustomerService(RSMotorsDbContext context)
		{
			this.context = context;
		}

		public async Task AddCustomer(AddCustomerViewModel model)
		{
			Customer customer = new Customer();
			customer.Id = model.Id;
			customer.FirstName = model.FirstName;
			customer.LastName = model.LastName;
			customer.Email = model.Email;
			customer.Phone = model.Phone;
			customer.Address = model.Address;

			await context.Customers.AddAsync(customer);

			await context.SaveChangesAsync();
		}

		
        public async Task<List<AllCustomersViewModel>> AllCustomers()
        {
			return await context.Customers
				.Select(a => new AllCustomersViewModel
				{
					Id = a.Id,
					FirstName = a.FirstName,
					LastName = a.LastName,
					Email = a.Email,
					Phone = a.Phone,
					Address = a.Address,
				}).ToListAsync();
        }

        public async Task<bool> DeleteCustomer(Guid? id)
        {
			Customer? customer = await context.Customers.FirstOrDefaultAsync(cu => cu.Id == id);

			if (customer != null)
			{
				context.Remove(customer);
				await context.SaveChangesAsync();
				return true;
			}

			return false;
        }

        public async Task<bool> EditCustomer(EditCustomerViewModel editCustomerViewModel)
        {
			Customer? customer = await context.Customers.FirstOrDefaultAsync(cu => cu.Id == editCustomerViewModel.Id);

			if (customer != null)
			{
				customer.FirstName = editCustomerViewModel.FirstName;
				customer.LastName = editCustomerViewModel.LastName;
				customer.Email = editCustomerViewModel.Email;
				customer.Phone = editCustomerViewModel.Phone;
				customer.Address = editCustomerViewModel.Address;

				await context.SaveChangesAsync();

				return true;
			}

			return false;
        }

        public async Task<List<string>> GetAllNames()
		{
			return await context.Customers.Select(c => c.FirstName).ToListAsync();
		}

		public async Task<CustomerViewModel> GetCustomer(Guid id)
		{
			Customer? customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);

			CustomerViewModel viewModel = new CustomerViewModel();

			viewModel.Id = customer!.Id;
			viewModel.FirstName = customer.FirstName;
			viewModel.LastName = customer.LastName;
			viewModel.Email = customer.Email;
			viewModel.Phone = customer.Phone;
			viewModel.Address = customer.Address;

			return viewModel;

		}

        public async Task<EditCustomerViewModel> GetCustomerForEdit(Guid id)
        {

            Customer? customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            EditCustomerViewModel viewModel = new EditCustomerViewModel();
            viewModel.Id = customer!.Id;
            viewModel.FirstName = customer.FirstName;
            viewModel.LastName = customer.LastName;
            viewModel.Email = customer.Email;
            viewModel.Phone = customer.Phone;
            viewModel.Address = customer.Address;

            return viewModel;
        }
    }
}
