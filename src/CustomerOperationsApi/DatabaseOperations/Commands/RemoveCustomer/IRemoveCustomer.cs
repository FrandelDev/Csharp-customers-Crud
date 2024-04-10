using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Database.Commands.RemoveCustomer
{
    public interface IRemoveCustomer
    {
        Task<Customer> Execute(string customerId);
    }
}
