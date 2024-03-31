using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Services
{
    public interface ICustomerService
    {
       CustomerModel GetCustomerById(string id);
    }
}
