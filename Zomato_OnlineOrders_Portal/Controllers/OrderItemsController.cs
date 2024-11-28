using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces;

namespace Zomato_OnlineOrders_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {

        IOrderItemsServices _oditsv;
        public OrderItemsController(IOrderItemsServices oditsv)
        {
            _oditsv = oditsv;
        }
        [HttpPost]
        [Route("AddOrderItems")]
        public async Task<IActionResult> post([FromBody] OrderItemDto oddetail)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var cmdata = await _oditsv.AddOrderItems(oddetail);
                    return StatusCode(StatusCodes.Status200OK, "orderitem added sucessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "serever not found");
            }
        }
        [HttpDelete]
        [Route("DeleteOrderItemsById/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var cmdata = await _oditsv.DeleteOrderItems(id);
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
        [Route("GetAllOrderItems")]
        public async Task<IActionResult> GetAllOrderItems()
        {
            try
            {
                var cmdata = await _oditsv.GetAllOrderItems();
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
        [Route("GetOrderItemsById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var cmdata = await _oditsv.GetAllOrderItemsById(id);
                return StatusCode(StatusCodes.Status200OK, cmdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateOrderItems")]
        public async Task<IActionResult> put([FromBody] OrderItemDto oddto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var cmdata = await _oditsv.UpdateOrderItems(oddto);
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
