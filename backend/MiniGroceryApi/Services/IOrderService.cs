using MiniGroceryApi.Models.DTOs;

namespace MiniGroceryApi.Services
{
  public interface IOrderService
  {
    Task<(bool Success, string Message)> PlaceOrderAsync(CreateOrderRequest request);
  }
}