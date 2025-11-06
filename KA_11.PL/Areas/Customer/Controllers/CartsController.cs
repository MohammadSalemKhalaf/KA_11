using KA_11.BLL.Services.Interfaces;
using KA_11.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KA_11.PL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost("")]
        public IActionResult AddToCart([FromBody] CartRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _cartService.AddToCart(userId, request);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("")]
        public IActionResult GetUserCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = _cartService.GetCartSummary(userId);
            return Ok(response);
        }

    }
}
