using MiniGroceryApi.Models;

namespace MiniGroceryApi.Repositories
{
  public interface IOrderRepository
  {
    Task AddAsync(Order order);
  }
}