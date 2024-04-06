using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(string id);
    }
}
