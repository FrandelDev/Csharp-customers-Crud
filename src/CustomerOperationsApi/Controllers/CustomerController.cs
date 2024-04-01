using CustomerOperationsApi.Models;
using CustomerOperationsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOperationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromServices]ICustomerService customerService, string id = "002-2345678-9")
        {
            var customer = await customerService.GetCustomerById(id);
            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK,"requerimiento de datos",customer));
        }
    }
}
