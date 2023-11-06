using Microsoft.EntityFrameworkCore;

using RSMotors.Core.Interfaces;
using RSMotors.Infrastructure;
using RSMotors.Infrastructure.Models;
using RSMotors.Web.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		
        public async Task<List<CustomersViewModel>> AllCustomers()
        {
			return await context.Customers
				.Select(a => new CustomersViewModel
				{
					Id = a.Id,
					FirstName = a.FirstName,
					LastName = a.LastName,
					Email = a.Email,
					Phone = a.Phone,
					Address = a.Address,
				}).ToListAsync();
        }

		public async Task<List<string>> GetAllNames()
		{
			return await context.Customers.Select(c => c.FirstName).ToListAsync();
		}

		public async Task<CustomersViewModel> GetCustomer(Guid id)
		{
			Customer? customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);

			CustomersViewModel viewModel = new CustomersViewModel();
			viewModel.Id = customer.Id;
			viewModel.FirstName = customer.FirstName;
			viewModel.LastName = customer.LastName;
			viewModel.Email = customer.Email;
			viewModel.Phone = customer.Phone;
			viewModel.Address = customer.Address;

			return viewModel;

		}
	}
}
