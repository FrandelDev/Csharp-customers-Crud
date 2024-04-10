using CustomerOperationsApi.Models;
using CustomerOperationsApi.Services;
using System.Text.Json;

namespace CustomerOperationsApi.Database.Commands.InsertCustomer
{
    public class AddCustomer : IAddCustomer
    {
        public async Task<Customer> Execute(Customer customer)
        {
           var db = DatabaseService.Connection.GetDatabase();
            await db.StringSetAsync(customer.CustomerId,JsonSerializer.Serialize(customer));
            await db.SetAddAsync("customerKeys",customer.CustomerId);
            return customer;
        }
    }
}
