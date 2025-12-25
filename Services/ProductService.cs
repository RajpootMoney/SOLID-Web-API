using SOLIDWebAPI.Models;
using SOLIDWebAPI.Repositories;
using SOLIDWebAPI.Validators;

namespace SOLIDWebAPI.Services;

/// <summary>
/// SINGLE RESPONSIBILITY PRINCIPLE (SRP):
/// This class has ONE responsibility: Business logic for Product operations.
/// It doesn't handle data access (delegated to IProductRepository) or validation (delegated to IValidator).
/// 
/// DEPENDENCY INVERSION PRINCIPLE (DIP):
/// This class depends on abstractions (IProductRepository, IValidator) not concrete implementations.
/// Dependencies are injected through constructor, making the class testable and flexible.
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<Product> _validator;

    // Constructor injection - DIP: Depend on abstractions
    public ProductService(IProductRepository productRepository, IValidator<Product> validator)
    {
        _productRepository = productRepository;
        _validator = validator;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        // Business logic: Simple retrieval, no transformation needed
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        // Business logic: Simple retrieval, no transformation needed
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        // Business logic: Validate before creating
        if (!_validator.Validate(product))
        {
            throw new ArgumentException("Product validation failed", nameof(product));
        }

        // Business logic: Set creation timestamp
        product.CreatedAt = DateTime.UtcNow;

        return await _productRepository.CreateAsync(product);
    }

    public async Task<Product?> UpdateProductAsync(int id, Product product)
    {
        // Business logic: Check if product exists
        if (!await _productRepository.ExistsAsync(id))
        {
            return null;
        }

        // Business logic: Validate before updating
        if (!_validator.Validate(product))
        {
            throw new ArgumentException("Product validation failed", nameof(product));
        }

        return await _productRepository.UpdateAsync(id, product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        // Business logic: Check if product exists before deletion
        if (!await _productRepository.ExistsAsync(id))
        {
            return false;
        }

        return await _productRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
    {
        // Business logic: Validate price range
        if (minPrice < 0 || maxPrice < 0 || minPrice > maxPrice)
        {
            throw new ArgumentException("Invalid price range", nameof(minPrice));
        }

        return await _productRepository.GetByPriceRangeAsync(minPrice, maxPrice);
    }
}


