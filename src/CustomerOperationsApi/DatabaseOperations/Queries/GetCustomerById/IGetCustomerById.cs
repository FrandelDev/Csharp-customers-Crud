using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Database.Queries.GetCustomerById
{
    public interface IGetCustomerById
    {
        Task<Customer> Execute(string customerId);
    }
}
