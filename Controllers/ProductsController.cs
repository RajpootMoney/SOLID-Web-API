using Microsoft.AspNetCore.Mvc;
using SOLIDWebAPI.Models;
using SOLIDWebAPI.Services;

namespace SOLIDWebAPI.Controllers;

/// <summary>
/// SINGLE RESPONSIBILITY PRINCIPLE (SRP):
/// This controller has ONE responsibility: Handle HTTP requests/responses for Products.
/// It doesn't contain business logic (delegated to IProductService) or data access (delegated to repositories).
/// 
/// DEPENDENCY INVERSION PRINCIPLE (DIP):
/// This controller depends on IProductService abstraction, not concrete implementation.
/// Dependencies are injected through constructor.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    // Constructor injection - DIP: Depend on abstractions
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// GET: api/products
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    /// <summary>
    /// GET: api/products/5
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    /// <summary>
    /// GET: api/products/price-range?minPrice=10&maxPrice=100
    /// </summary>
    [HttpGet("price-range")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPriceRange(
        [FromQuery] decimal minPrice, 
        [FromQuery] decimal maxPrice)
    {
        try
        {
            var products = await _productService.GetProductsByPriceRangeAsync(minPrice, maxPrice);
            return Ok(products);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// POST: api/products
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        try
        {
            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// PUT: api/products/5
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        try
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, product);
            
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// DELETE: api/products/5
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var deleted = await _productService.DeleteProductAsync(id);
        
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}


