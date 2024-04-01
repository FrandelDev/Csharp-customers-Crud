using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerModel[] DefaultCustomers = new CustomerModel[]
        {
           new() {
        Id = "001-1234567-8",
        FullName = "Juan Perez",
        Email = "juan.perez@example.com",
        Phone = "809-123-4567",
        Nationality = "Dominicana",
        City = "Santo Domingo",
        Gender = 'M'
    },
    new() {
        Id = "002-2345678-9",
        FullName = "Maria Rodriguez",
        Email = "maria.rodriguez@example.com",
        Phone = "809-234-5678",
        Nationality = "Dominicana",
        City = "Santiago",
        Gender = 'F'
    },
    new() {
        Id = "003-3456789-0",
        FullName = "Carlos Fernandez",
        Email = "carlos.fernandez@example.com",
        Phone = "809-345-6789",
        Nationality = "Dominicana",
        City = "La Romana",
        Gender = 'M'
    }
        };

        public async Task<CustomerModel> GetCustomerById(string id) => DefaultCustomers.FirstOrDefault(customer => customer.Id == id);//return "hola"+id;
    }
}
