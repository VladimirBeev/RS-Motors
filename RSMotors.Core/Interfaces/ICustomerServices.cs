using RSMotors.Web.ViewModel.Customer;

namespace RSMotors.Core.Interfaces
{
    public interface ICustomerServices
	{
		Task AddCustomer(AddCustomerViewModel model);
        Task<List<CustomersViewModel>> AllCustomers();
    }
}
