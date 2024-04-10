using CustomerOperationsApi.Models;
using CustomerOperationsApi.Services;
using System.Text.Json;

namespace CustomerOperationsApi.Database.Queries.GetAllCustomers
{
    public class GetAllCustomers : IGetAllCustomers
    {


        public async Task<List<Customer>> Execute()
        {
            var db = DatabaseService.Connection.GetDatabase();

            List<Customer> defaultCustomers = new List<Customer>
{
    new Customer
    {
        CustomerId = "001-1234567-8",
        FirstName = "Juan",
        SecondName = "Carlos",
        LastName = "Perez",
        SecondLastName = "Gomez",
        Nationality = "Dominicana",
        BirthDate = new DateTime(1985, 7, 20),
        Gender = "M",
        Contacts = new List<Contact>
        {
            new Contact
            {
                PhoneNumber = "809-123-4567",
                Email = "juan.perez@gmail.com"
            }
        },
        Address = new Address
        {
            CountryName = "República Dominicana",
            CityName = "Santo Domingo",
            RegionName = "Distrito Nacional",
            SectorName = "Piantini",
            PostalCode = "10129"
        }
    },
    new Customer
    {
        CustomerId = "002-2345678-9",
        FirstName = "Maria",
        SecondName = "Isabel",
        LastName = "Rodriguez",
        SecondLastName = "Santos",
        Nationality = "Dominicana",
        BirthDate = new DateTime(1990, 5, 15),
        Gender = "F",
        Contacts = new List<Contact>
        {
            new Contact
            {
                PhoneNumber = "809-234-5678",
                Email = "maria.rodriguez@gmail.com"
            }
        },
        Address = new Address
        {
            CountryName = "República Dominicana",
            CityName = "Santiago",
            RegionName = "Santiago",
            SectorName = "Los Jardines",
            PostalCode = "51000"
        }
    },
    new Customer
    {
        CustomerId = "003-3456789-0",
        FirstName = "Pedro",
        SecondName = null,
        LastName = "Martinez",
        SecondLastName = "Lopez",
        Nationality = "Dominicana",
        BirthDate = new DateTime(1987, 3, 30),
        Gender = "M",
        Contacts = new List<Contact>
        {
            new Contact
            {
                PhoneNumber = "809-345-6789",
                Email = "pedro.martinez@gmail.com"
            },
            new Contact
            {
                PhoneNumber = "809-345-6789"
            }
        },
        Address = new Address
        {
            CountryName = "República Dominicana",
            CityName = "La Romana",
            RegionName = "La Romana",
            SectorName = "Buena Vista Norte",
            PostalCode = "22000"
        }
    }
};




            db.StringSet(defaultCustomers[0].CustomerId, JsonSerializer.Serialize(defaultCustomers[0]));
            db.StringSet(defaultCustomers[1].CustomerId, JsonSerializer.Serialize(defaultCustomers[1]));
            db.StringSet(defaultCustomers[2].CustomerId, JsonSerializer.Serialize(defaultCustomers[2]));

            await db.SetAddAsync("customerKeys", defaultCustomers[0].CustomerId);
            await db.SetAddAsync("customerKeys", defaultCustomers[1].CustomerId);
            await db.SetAddAsync("customerKeys", defaultCustomers[2].CustomerId);

            var customerKeys = await db.SetMembersAsync("customerKeys");


            List<Customer> customers = new();

            foreach (var key in customerKeys)
            {
                customers.Add(JsonSerializer.Deserialize<Customer>(await db.StringGetAsync(Convert.ToString(key))));
            }



            return customers;
        }
    }
}
