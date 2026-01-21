using Microsoft.AspNetCore.Mvc;
using MiniGroceryApi.Models.DTOs;
using MiniGroceryApi.Services;

namespace MiniGroceryApi.Controllers
{
  [ApiController]
  [Route("orders")]
  public class OrdersController : ControllerBase
  {
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
      _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] CreateOrderRequest request)
    {
      var result = await _orderService.PlaceOrderAsync(request);

      if (!result.Success)
      {
        return BadRequest(new { message = result.Message });
      }

      return Ok(new { message = result.Message });
    }
  }
}