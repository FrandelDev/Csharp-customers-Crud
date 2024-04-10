using CustomerOperationsApi.Models;
using CustomerOperationsApi.Services;
using System.Text.Json;

namespace CustomerOperationsApi.Database.Queries.GetCustomerById
{
    public class GetCustomerById : IGetCustomerById
    {

        public async Task<Customer> Execute(string customerId)
        {
            var db = DatabaseService.Connection.GetDatabase();
            var customer = JsonSerializer.Deserialize<Customer>(await db.StringGetAsync(customerId));
            return customer;
        }
    }
}
