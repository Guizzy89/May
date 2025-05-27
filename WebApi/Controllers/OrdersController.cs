using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.BusinessLogicLayer.Services;
using WebApplication1.DataAccessLayer.Models;
namespace WebApplication1.WebApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders([FromQuery] Guid userId)
        {
            var orders = _orderService.GetOrdersForUser(userId);
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var placedOrder = _orderService.PlaceOrder(order);
            return CreatedAtAction(nameof(GetOrders), new { userId = placedOrder.UserId }, placedOrder);
        }
    }
}
