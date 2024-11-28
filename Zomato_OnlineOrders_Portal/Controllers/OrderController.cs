using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces;

namespace Zomato_OnlineOrders_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices _osdr;
        public OrderController(IOrderServices osdr)
        {
            _osdr = osdr;
        }
        [HttpPost]
        [Route("AddOrders")]
        public async Task<IActionResult> post([FromBody] OrderDto ordetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var res = await _osdr.AddOrders(ordetail);
                    return StatusCode(StatusCodes.Status201Created, "order created");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteOrdersById/{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var res = await _osdr.DeleteOrders(id);
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "order not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, "order is deleted");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var res = await _osdr.GetAllOrders();
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpPut]
        [Route("UpdateOrders")]
        public async Task<IActionResult> put([FromBody] OrderDto ordetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var res = await _osdr.UpdateOrders(ordetail);
                    return StatusCode(StatusCodes.Status200OK, "order upadted");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetAllOrdersById/{id}")]
        public async Task<IActionResult> GetAllOrdersById(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var res = await _osdr.GetAllOrdersById(id);
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "no id found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
