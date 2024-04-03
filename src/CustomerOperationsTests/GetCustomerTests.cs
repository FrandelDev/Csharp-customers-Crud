using Castle.Core.Resource;
using CustomerOperationsApi.Controllers;
using CustomerOperationsApi.Models;
using CustomerOperationsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using NuGet.Frameworks;
using Xunit;

namespace CustomerOperationsTests
{
    public class GetCustomerTests
    {
        private readonly CustomerController _customerController;
        private readonly ICustomerService _customerService;

        public GetCustomerTests()
        {
            _customerController = new CustomerController();
            _customerService = new CustomerService();
        }

        [Fact]
        public async void GetCustomer_Ok()
        {
            var result = await _customerController.GetCustomer(_customerService, "003-3456789-0");
            Assert.NotNull(result);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async void GetCustomer_NotFound()
        {
            var result = await _customerController.GetCustomer(_customerService, "000-0000000-0");
            Assert.NotNull(result);

           var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(404, objectResult.StatusCode);
        }

        [Fact]
        public async void GetCustomer_BadRequest()
        {
            var result = await _customerController.GetCustomer(_customerService, "003-34567890");
            Assert.NotNull(result);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, objectResult.StatusCode);
        }

    }
}
