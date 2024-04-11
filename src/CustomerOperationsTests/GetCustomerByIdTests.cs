using CustomerOperationsApi.Controllers;
using CustomerOperationsApi.Database.Queries.GetAllCustomers;
using CustomerOperationsApi.Database.Queries.GetCustomerById;
using CustomerOperationsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOperationsTests
{
    public class GetCustomerByIdTests
    {
        private readonly CustomerController _customerController;
        private readonly IGetCustomerById _getCustomerByIdQuery;
        public GetCustomerByIdTests()
        {
            _customerController = new CustomerController();
            _getCustomerByIdQuery = new GetCustomerById();
        }

        [Fact]
        public async void GetCustomer_Ok()
        {
            var createDefaultCustomers = new GetAllCustomers();
            createDefaultCustomers.Execute();

            var result = await _customerController.GetCustomerById(_getCustomerByIdQuery, "002-2345678-9");
            Assert.NotNull(result);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async void GetCustomer_NotFound()
        {
            var result = await _customerController.GetCustomerById(_getCustomerByIdQuery, "000-0000000-2");
            Assert.NotNull(result);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(404, objectResult.StatusCode);
        }

        [Fact]
        public async void GetCustomer_BadRequest()
        {
            var result = await _customerController.GetCustomerById(_getCustomerByIdQuery, "003-34567890");
            Assert.NotNull(result);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, objectResult.StatusCode);
        }

    }
}
