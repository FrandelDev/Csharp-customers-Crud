using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Database.Commands.InsertCustomer
{
    public interface IAddCustomer
    {
        Task<Customer> Execute(Customer customer);
    }
}
