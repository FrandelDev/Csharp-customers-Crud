using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Database.Commands.UpdateCustomer
{
    public interface IUpdateCustomer
    {
        Task<Customer> Execute(Customer customer, string customerId);
    }
}
