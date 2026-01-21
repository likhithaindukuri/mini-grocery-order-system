using Microsoft.EntityFrameworkCore;
using MiniGroceryApi.Models;
using MiniGroceryApi.Models.DTOs;
using MiniGroceryApi.Repositories;

namespace MiniGroceryApi.Services
{
  public class OrderService : IOrderService
  {
    private readonly AppDbContext _context;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(
      AppDbContext context,
      IOrderRepository orderRepository,
      IProductRepository productRepository)
    {
      _context = context;
      _orderRepository = orderRepository;
      _productRepository = productRepository;
    }

    public async Task<(bool Success, string Message)> PlaceOrderAsync(CreateOrderRequest request)
    {
      await using var transaction = await _context.Database.BeginTransactionAsync();

      try
      {
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product == null)
        {
          return (false, "Product not found. Please check the product ID and try again.");
        }

        if (product.Stock < request.Quantity)
        {
          return (false, "Insufficient stock. Reduce the quantity or restock the product before ordering.");
        }

        product.Stock -= request.Quantity;
        await _productRepository.UpdateAsync(product);

        var order = new Order
        {
          ProductId = product.Id,
          Quantity = request.Quantity,
          TotalPrice = product.Price * request.Quantity,
          CreatedAt = DateTime.UtcNow
        };

        await _orderRepository.AddAsync(order);

        await transaction.CommitAsync();
        return (true, $"Order for {product.Name} placed successfully.");
      }
      catch
      {
        await transaction.RollbackAsync();
        return (false, "Order failed due to an unexpected error. Try again or contact support if the issue persists.");
      }
    }
  }
}