using CustomerOperationsApi.Models;
using CustomerOperationsApi.Services;
using StackExchange.Redis;
using System.Text.Json;

namespace CustomerOperationsApi.Database.Commands.UpdateCustomer
{
    public class UpdateCustomer : IUpdateCustomer
    {
        public async Task<Customer?> Execute(Customer newCustomerData, string customerId)
        {
            var db = DatabaseService.Connection.GetDatabase();

            var allCustomersId = db.StringGet(customerId);
            if (allCustomersId.IsNull)
            {
                return null;
            }
          
                await db.StringSetAsync(customerId, JsonSerializer.Serialize(newCustomerData));
                return newCustomerData;


        }
    }
}
