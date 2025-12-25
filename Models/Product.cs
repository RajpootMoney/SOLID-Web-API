namespace SOLIDWebAPI.Models;

/// <summary>
/// SINGLE RESPONSIBILITY PRINCIPLE (SRP):
/// This class represents ONLY the Product data structure.
/// It doesn't contain business logic, validation, or data access code.
/// </summary>
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

