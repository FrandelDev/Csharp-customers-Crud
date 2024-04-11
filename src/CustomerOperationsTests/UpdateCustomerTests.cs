using CustomerOperationsApi.Controllers;
using CustomerOperationsApi.Database.Commands.UpdateCustomer;
using CustomerOperationsApi.Database.Queries.GetAllCustomers;
using CustomerOperationsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOperationsTests
{
    public class UpdateCustomerTests
    {
        private readonly IUpdateCustomer _updateCustomerCommnand;
        private readonly CustomerController _customerController;

        public UpdateCustomerTests()
        {
            _updateCustomerCommnand = new UpdateCustomer();
            _customerController = new CustomerController();
        }

        [Fact]
        public async void Can_update_customer()
        {
            Customer defaultCustomer = new()
            {
                CustomerId = "003-3456789-0",
                FirstName = "NameTest Updated",
                SecondName = "SecondNameTest",
                LastName = "LastNameTest Updated",
                SecondLastName = "SecondLastNameTest",
                Nationality = "NationalityTest",
                Gender = "M",
                BirthDate = DateTime.Parse("02-12-1999"),
                Contacts = new List<Contact> { new Contact { Email = "email@test.com", PhoneNumber = "000-000-0000" } },
                Address = new Address
                {
                    CityName = "CityTest",
                    CountryName = "CountryNameTest Updated",
                    PostalCode = "12345",
                    RegionName = "RegionTest",
                    SectorName = "SectorTest"
                }
            };

            var result = await _customerController.UpdateCustomer(_updateCustomerCommnand, defaultCustomer, "003-3456789-0");
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, objectResult.StatusCode);
        }

        [Fact]
        public async void Cant_update_customer()
        {
            Customer defaultCustomer = new()
            {
                CustomerId = "003-3456789-0",
                FirstName = "NameTest",
                SecondName = "SecondNameTest",
                LastName = null,
                SecondLastName = "SecondLastNameTest",
                Nationality = "NationalityTest",
                Gender = "M",
                BirthDate = DateTime.UtcNow,
                Contacts = null,
                Address = null
            };

            var result = await _customerController.UpdateCustomer(_updateCustomerCommnand, defaultCustomer, "003-34567890");
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact]
        public async void GetCustomerToUpdate_NotFound()
        {
            Customer defaultCustomer = new()
            {
                CustomerId = "000-0000000-1",
                FirstName = "NameTest",
                SecondName = "SecondNameTest",
                LastName = null,
                SecondLastName = "SecondLastNameTest",
                Nationality = "NationalityTest",
                Gender = "M",
                BirthDate = DateTime.UtcNow,
                Contacts = null,
                Address = null
            };
            var result = await _customerController.UpdateCustomer(_updateCustomerCommnand, defaultCustomer, "000-0000000-1");
            Assert.NotNull(result);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(404, objectResult.StatusCode);
        }


        [Fact]
        public async void UpdateCustomer_Return_CustomerObject()
        {
            Customer defaultCustomer = new()
            {
                CustomerId = "002-2345678-9",
                FirstName = "NameTest ",
                SecondName = "SecondNameTest",
                LastName = "LastNameTest",
                SecondLastName = "SecondLastNameTest",
                Nationality = "NationalityTest",
                Gender = "M",
                BirthDate = DateTime.Parse("02-12-1999"),
                Contacts = new List<Contact> { new Contact { Email = "email@test.com", PhoneNumber = "000-000-0000" } },
                Address = new Address
                {
                    CityName = "CityTest",
                    CountryName = "CountryNameTest",
                    PostalCode = "12345",
                    RegionName = "RegionTest",
                    SectorName = "SectorTest"
                }
            };
            var createDefaultCustomers = new GetAllCustomers();
            createDefaultCustomers.Execute();

            var updateCustomerQuery = new UpdateCustomer();
            var result = await updateCustomerQuery.Execute(defaultCustomer, "002-2345678-9");

            Assert.NotNull(result);
            Assert.IsType<Customer>(result);

        }
    }
}
