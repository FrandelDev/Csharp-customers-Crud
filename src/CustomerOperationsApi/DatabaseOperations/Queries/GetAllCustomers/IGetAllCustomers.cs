using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Database.Queries.GetAllCustomers
{
    public interface IGetAllCustomers
    {
        Task<List<Customer>> Execute();
    }
}
