using Microsoft.AspNetCore.Mvc;
using MiniGroceryApi.Repositories;

namespace MiniGroceryApi.Controllers
{
  [ApiController]
  [Route("products")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
      var products = await _productRepository.GetAllAsync();
      return Ok(products);
    }
  }
}