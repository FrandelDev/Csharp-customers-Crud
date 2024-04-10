using CustomerOperationsApi.Controllers;
using CustomerOperationsApi.Database.Commands.InsertCustomer;
using CustomerOperationsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOperationsTests
{
    public class AddCustomerTests
    {
        private readonly IAddCustomer _addCustomerCommnand;
        private readonly CustomerController _customerController;

        public AddCustomerTests()
        {
            _addCustomerCommnand = new AddCustomer();
            _customerController = new CustomerController();
        }

        [Fact]
        public async void Can_add_customer()
        {
            Customer defaultCustomer = new()
            {
                CustomerId = "000-0000000-0",
                FirstName = "NameTest",
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

            var result = await _customerController.AddCustomer(_addCustomerCommnand,defaultCustomer);
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, objectResult.StatusCode);
        }

        [Fact]
        public async void Cant_add_customer()
        {
            Customer defaultCustomer = new()
            {
                CustomerId = "000-000-0",
                FirstName = "NameTest",
                SecondName = "SecondNameTest",
                LastName = null,
                SecondLastName = "SecondLastNameTest",
                Nationality = "NationalityTest",
                Gender = "M",
                BirthDate = DateTime.UtcNow,
                Contacts =null,
                Address = null
            };

            var result = await _customerController.AddCustomer(_addCustomerCommnand, defaultCustomer);
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, objectResult.StatusCode);
        }
    }
}
