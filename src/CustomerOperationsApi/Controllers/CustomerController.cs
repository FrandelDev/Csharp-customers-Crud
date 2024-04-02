using CustomerOperationsApi.Exceptions;
using CustomerOperationsApi.Services;
using CustomerOperationsApi.Validators.CustomerValidator;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOperationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionsManager))]
    public class CustomerController : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromServices] ICustomerService customerService, string id = "002-2345678-9")
        {
            var validation = CustomerValidator.IsValid(id);

            if (validation.IsSuccess)
            {
                try
                {

                    var customer = await customerService.GetCustomerById(id);
                    if (customer != null)
                    {
                        return StatusCode(StatusCodes.Status200OK,
                                                ResponseApiService.Response(StatusCodes.Status200OK, "requerimiento de datos", customer));
                    }
                    else
                    {
                        throw new Exception("Id Not Found in our Database");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                       ResponseApiService.Response(StatusCodes.Status404NotFound, ex.Message));
                }

            }
            return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validation.Message));
        }
    }
}
