using CustomerOperationsApi.Controllers;
using CustomerOperationsApi.Database.Queries.GetAllCustomers;
using CustomerOperationsApi.Models;
using CustomerOperationsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOperationsTests
{
    public class GetAllCustomersTest
    {
        private readonly CustomerController _customerController;
        private GetAllCustomers _getAllCustomersQuery;
        public GetAllCustomersTest()
        {
            _customerController = new CustomerController();
            _getAllCustomersQuery = new GetAllCustomers();
        }

        [Fact]
        public async void GetAllCustomers_Ok()
        {

            var result = await _customerController.GetAllCustomers(_getAllCustomersQuery);
            Assert.NotNull(result);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200,objectResult.StatusCode);
        }
        [Fact]
        public async void GetAllCustomers_Return_ObjectList()
        {
            var createDefaultCustomers = new GetAllCustomers();
            createDefaultCustomers.Execute();

            var result = await _getAllCustomersQuery.Execute();

            Assert.NotNull(result);
            Assert.IsType<List<Customer>>(result);
           
        }
    }
}
