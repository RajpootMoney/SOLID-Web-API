using SOLIDWebAPI.Models;

namespace SOLIDWebAPI.Validators;

/// <summary>
/// SINGLE RESPONSIBILITY PRINCIPLE (SRP):
/// This class has ONE responsibility: Validating Product entities.
/// It doesn't handle business logic, data access, or presentation.
/// 
/// OPEN/CLOSED PRINCIPLE (OCP):
/// This class is open for extension (you can inherit and add more validation rules)
/// but closed for modification (existing validation logic doesn't need to change).
/// 
/// LISKOV SUBSTITUTION PRINCIPLE (LSP):
/// This class can be substituted for any IValidator<Product> without breaking functionality.
/// Any code expecting IValidator<Product> will work correctly with this implementation.
/// </summary>
public class ProductValidator : IValidator<Product>
{
    public bool Validate(Product product)
    {
        if (product == null)
            return false;

        // Validation rules for Product
        if (string.IsNullOrWhiteSpace(product.Name))
            return false;

        // Price must be positive
        if (product.Price < 0)
            return false;

        // Name length validation
        if (product.Name.Length < 2 || product.Name.Length > 200)
            return false;

        return true;
    }
}


