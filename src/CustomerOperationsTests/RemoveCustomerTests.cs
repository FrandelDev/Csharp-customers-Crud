using CustomerOperationsApi.Controllers;
using CustomerOperationsApi.Database.Commands.InsertCustomer;
using CustomerOperationsApi.Database.Commands.RemoveCustomer;
using CustomerOperationsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOperationsTests
{
    public class RemoveCustomerTests
    {
        private readonly IRemoveCustomer _removeCustomerCommnand;
        private readonly CustomerController _customerController;

        public RemoveCustomerTests()
        {
            _removeCustomerCommnand = new RemoveCustomer();
            _customerController = new CustomerController();
        }

        [Fact]
        public async void Can_remove_customer()
        {

            var result = await _customerController.RemoveCustomer(_removeCustomerCommnand, "001-1234567-8");
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async void Cant_remove_customer()
        {
            var result = await _customerController.RemoveCustomer(_removeCustomerCommnand, "000-0000000-1");
            Assert.NotNull(result);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(404, objectResult.StatusCode);
        }

     
    }
}

