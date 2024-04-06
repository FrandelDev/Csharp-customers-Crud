using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> DefaultCustomers = new List<Customer>();


      

        public async Task<Customer> GetCustomerById(string id) => DefaultCustomers.FirstOrDefault(customer => customer.CustomerId == id);

    }
}
