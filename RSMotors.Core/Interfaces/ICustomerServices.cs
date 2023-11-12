using RSMotors.Web.ViewModel.Customer;

namespace RSMotors.Core.Interfaces
{
    public interface ICustomerServices
	{
		Task AddCustomer(AddCustomerViewModel model);
        Task<List<AllCustomersViewModel>> AllCustomers();
        Task<bool> DeleteCustomer(Guid? id);
        Task<bool> EditCustomer(EditCustomerViewModel editCustomerViewModel);
        Task<List<string>> GetAllNames();
		Task<CustomerViewModel> GetCustomer(Guid id);
        Task<EditCustomerViewModel> GetCustomerForEdit(Guid id);
    }
}
