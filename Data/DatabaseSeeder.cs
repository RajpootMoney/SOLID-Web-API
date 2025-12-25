using SOLIDWebAPI.Models;

namespace SOLIDWebAPI.Data;

/// <summary>
/// SINGLE RESPONSIBILITY PRINCIPLE (SRP):
/// This class has ONE responsibility: Seeding the database with initial sample data.
/// It doesn't handle business logic, validation, or data access operations.
/// </summary>
public static class DatabaseSeeder
{
    /// <summary>
    /// Seeds the database with sample data for demonstration purposes.
    /// </summary>
    public static void Seed(ApplicationDbContext context)
    {
        // Check if database already has data
        if (context.Users.Any() || context.Products.Any())
        {
            return; // Database already seeded
        }

        // Sample Users
        var users = new List<User>
        {
            new User
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                CreatedAt = DateTime.UtcNow.AddDays(-30)
            },
            new User
            {
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                CreatedAt = DateTime.UtcNow.AddDays(-25)
            },
            new User
            {
                Name = "Bob Johnson",
                Email = "bob.johnson@example.com",
                CreatedAt = DateTime.UtcNow.AddDays(-20)
            },
            new User
            {
                Name = "Alice Williams",
                Email = "alice.williams@example.com",
                CreatedAt = DateTime.UtcNow.AddDays(-15)
            },
            new User
            {
                Name = "Charlie Brown",
                Email = "charlie.brown@example.com",
                CreatedAt = DateTime.UtcNow.AddDays(-10)
            }
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        // Sample Products
        var products = new List<Product>
        {
            new Product
            {
                Name = "Laptop",
                Price = 999.99m,
                Description = "High-performance laptop with 16GB RAM and 512GB SSD",
                CreatedAt = DateTime.UtcNow.AddDays(-28)
            },
            new Product
            {
                Name = "Smartphone",
                Price = 699.99m,
                Description = "Latest smartphone with advanced camera and 5G connectivity",
                CreatedAt = DateTime.UtcNow.AddDays(-25)
            },
            new Product
            {
                Name = "Wireless Headphones",
                Price = 199.99m,
                Description = "Premium noise-cancelling wireless headphones",
                CreatedAt = DateTime.UtcNow.AddDays(-22)
            },
            new Product
            {
                Name = "Tablet",
                Price = 449.99m,
                Description = "10-inch tablet perfect for reading and entertainment",
                CreatedAt = DateTime.UtcNow.AddDays(-20)
            },
            new Product
            {
                Name = "Smart Watch",
                Price = 299.99m,
                Description = "Fitness tracking smartwatch with heart rate monitor",
                CreatedAt = DateTime.UtcNow.AddDays(-18)
            },
            new Product
            {
                Name = "Gaming Mouse",
                Price = 79.99m,
                Description = "Precision gaming mouse with RGB lighting",
                CreatedAt = DateTime.UtcNow.AddDays(-15)
            },
            new Product
            {
                Name = "Mechanical Keyboard",
                Price = 149.99m,
                Description = "RGB mechanical keyboard with Cherry MX switches",
                CreatedAt = DateTime.UtcNow.AddDays(-12)
            },
            new Product
            {
                Name = "Monitor",
                Price = 349.99m,
                Description = "27-inch 4K monitor with HDR support",
                CreatedAt = DateTime.UtcNow.AddDays(-10)
            }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}

