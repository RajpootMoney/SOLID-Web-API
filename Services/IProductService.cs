using SOLIDWebAPI.Models;

namespace SOLIDWebAPI.Services;

/// <summary>
/// DEPENDENCY INVERSION PRINCIPLE (DIP):
/// High-level modules (Controllers) depend on this abstraction, not concrete implementations.
/// This allows for easy testing and swapping implementations.
/// </summary>
public interface IProductService
{
    Task<Product?> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> CreateProductAsync(Product product);
    Task<Product?> UpdateProductAsync(int id, Product product);
    Task<bool> DeleteProductAsync(int id);
    Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
}


