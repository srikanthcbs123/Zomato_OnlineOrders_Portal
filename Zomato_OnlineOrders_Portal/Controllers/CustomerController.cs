using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces;

namespace Zomato_OnlineOrders_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        [Route("AddCustomers")]
        public async Task<IActionResult> post([FromBody] CustomerDto cmdetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var cmdata = await _customerService.AddCustomers(cmdetail);
                    return StatusCode(StatusCodes.Status200OK, "customer added sucessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "serever not found");
            }
        }
        [HttpDelete]
        [Route("DeleteCustomerById/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var cmdata = await _customerService.DeleteCustomers(id);
                if (cmdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, "id deleted");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "serever not found");
            }
        }
        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var cmdata = await _customerService.GetAllCustomers();
                if (cmdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, cmdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpGet]
        [Route("GetCustomersById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var cmdata = await _customerService.GetAllCustomersById(id);
                return StatusCode(StatusCodes.Status200OK, cmdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateCustomers")]
        public async Task<IActionResult> put([FromBody] CustomerDto cmdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var cmdata = await _customerService.UpdateCustomers(cmdto);
                    return StatusCode(StatusCodes.Status202Accepted, cmdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
