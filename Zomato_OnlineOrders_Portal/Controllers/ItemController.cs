using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces;

namespace Zomato_OnlineOrders_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        IItemServices _itservices;
        public ItemController(IItemServices itservices)
        {
            _itservices = itservices;
        }
        [HttpPost]
        [Route("AddItems")]
        public async Task<IActionResult> post([FromBody] ItemDto itdt)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var res = await _itservices.AddItems(itdt);
                    return StatusCode(StatusCodes.Status201Created, res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpPut]
        [Route("UpdateItems")]
        public async Task<IActionResult> put([FromBody] ItemDto itdt)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var res = await _itservices.UpdateItems(itdt);
                    return StatusCode(StatusCodes.Status200OK, "item updated sucessfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteItemById/{id}")]
        public async Task<IActionResult> DeleteItems(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var res = await _itservices.DeleteItems(id);
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, "id is deleted");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var res = await _itservices.GetAllItems();
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
        [HttpGet]
        [Route("GetAllItemById/{id}")]
        public async Task<IActionResult> GetAllItemById(int id)
        {
            try
            {
                var res = await _itservices.GetAllItemById(id);
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
    }
}
