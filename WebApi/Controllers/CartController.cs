using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.BusinessLogicLayer.Services;

namespace WebApplication1.WebApi.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET: /api/cart
        [HttpGet]
        public IActionResult GetCart()
        {
            var cart = _cartService.GetCurrentCart(HttpContext.Session);
            return Ok(cart);
        }

        // POST: /api/cart/add/{productId}/{qty}
        [HttpPost("add/{productId}/{qty}")]
        public IActionResult AddToCart(Guid productId, int qty)
        {
            _cartService.AddToCart(HttpContext.Session, productId, qty);
            return RedirectToAction("Index", "Home"); // Вернуть на главную страницу
        }

        // DELETE: /api/cart/delete/{itemId}
        [HttpDelete("delete/{itemId}")]
        public IActionResult RemoveFromCart(Guid itemId)
        {
            _cartService.RemoveFromCart(HttpContext.Session, itemId);
            return Ok();
        }
    }
}
