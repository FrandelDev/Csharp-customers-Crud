
using CustomerOperationsApi.Models;
using CustomerOperationsApi.Services;
using System.Text.Json;

namespace CustomerOperationsApi.Database.Commands.RemoveCustomer
{
    public class RemoveCustomer : IRemoveCustomer
    {
        public async Task<Customer> Execute(string customerId)
        {
            var db = DatabaseService.Connection.GetDatabase();

           var deletedCustomer = JsonSerializer.Deserialize<Customer>(Convert.ToString(await db.StringGetDeleteAsync(customerId)));

          await  db.SetRemoveAsync("customerKeys",customerId);

            return deletedCustomer;
        }
    }
}
