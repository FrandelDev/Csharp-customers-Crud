using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Services
{
    public interface ICustomerService
    {
        Task<CustomerModel> GetCustomerById(string id);
    }
}
