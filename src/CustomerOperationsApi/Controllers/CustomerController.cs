using CustomerOperationsApi.Database.Commands.InsertCustomer;
using CustomerOperationsApi.Database.Commands.RemoveCustomer;
using CustomerOperationsApi.Database.Commands.UpdateCustomer;
using CustomerOperationsApi.Database.Queries.GetAllCustomers;
using CustomerOperationsApi.Database.Queries.GetCustomerById;
using CustomerOperationsApi.Exceptions;
using CustomerOperationsApi.Models;
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
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(
            [FromServices] IGetAllCustomers getAllCustomersQuery
            )
        {
            try
            {
                var allCustomers = await getAllCustomersQuery.Execute();

                return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "get all customers", allCustomers));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromServices] IGetCustomerById getCustomerByIdQuery, string id)
        {
            var validationId = ValidateCustomerId.IsValid(id);

            if (validationId.IsSuccess)
            {
                try
                {

                    var customer = await getCustomerByIdQuery.Execute(id);
                    if (customer != null)
                    {
                        return StatusCode(StatusCodes.Status200OK,
                                                ResponseApiService.Response(StatusCodes.Status200OK, "get customer by identification", customer));
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
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validationId.Message));
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(
            [FromServices] IAddCustomer addCustomerCommand,
            [FromBody] Customer customer
            )
        {
            try
            {
                if (ValidateCustomerId.IsValid(customer.CustomerId).IsSuccess)
                {
                    var dataInserted = await addCustomerCommand.Execute(customer);
                    return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, null, dataInserted));
                }

                throw new Exception("Incorret Id Format");


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(
            [FromServices] IUpdateCustomer updateCustomerCommand,
            [FromBody] Customer customer,
            string id
            )
        {
            var validationId = ValidateCustomerId.IsValid(id);

            if (validationId.IsSuccess)
            {

                try
                {
                    
                        var dataInserted = await updateCustomerCommand.Execute(customer, id);
                        if (dataInserted != null)
                        {
                            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, null, dataInserted));
                        }
                        else
                        {
                            throw new Exception("Id Not Found in our Database");
                        }

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, ex.Message));
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validationId.Message));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCustomer([FromServices] IRemoveCustomer removeCustomerCommand, string id)
        {
            var validationId = ValidateCustomerId.IsValid(id);

            if (validationId.IsSuccess)
            {

                try
                {
                    if (ValidateCustomerId.IsValid(id).IsSuccess)
                    {
                        var deletedCustomer = await removeCustomerCommand.Execute(id);
                        return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, "successfuly removed", deletedCustomer));
                    }

                    throw new Exception("Incorret Id Format");


                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, ex.Message));
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validationId.Message));
        }

    }
}
