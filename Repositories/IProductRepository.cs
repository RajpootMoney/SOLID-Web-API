using SOLIDWebAPI.Models;

namespace SOLIDWebAPI.Repositories;

/// <summary>
/// INTERFACE SEGREGATION PRINCIPLE (ISP):
/// This interface contains ONLY methods related to Product operations.
/// It doesn't force implementers to implement User-related methods.
/// 
/// DEPENDENCY INVERSION PRINCIPLE (DIP):
/// High-level modules (Services) depend on this abstraction, not concrete implementations.
/// </summary>
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> CreateAsync(Product product);
    Task<Product?> UpdateAsync(int id, Product product);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable<Product>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
}

