using SOLIDWebAPI.Models;

namespace SOLIDWebAPI.Validators;

/// <summary>
/// OPEN/CLOSED PRINCIPLE (OCP) - EXAMPLE:
/// This class demonstrates the Open/Closed Principle by EXTENDING functionality
/// without modifying the existing ProductValidator class.
/// 
/// We can use this validator instead of ProductValidator when we need stricter validation,
/// without changing any existing code that uses IValidator<Product>.
/// 
/// LISKOV SUBSTITUTION PRINCIPLE (LSP):
/// This class can be substituted for ProductValidator anywhere IValidator<Product> is expected.
/// It maintains the same contract but provides additional validation.
/// </summary>
public class AdvancedProductValidator : IValidator<Product>
{
    public bool Validate(Product product)
    {
        if (product == null)
            return false;

        // All basic validations
        if (string.IsNullOrWhiteSpace(product.Name))
            return false;

        if (product.Price < 0)
            return false;

        if (product.Name.Length < 2 || product.Name.Length > 200)
            return false;

        // EXTENDED VALIDATION - OCP: Adding new rules without modifying existing code
        // Price must be at least $1.00
        if (product.Price < 1.00m)
            return false;

        // Description should not be empty for advanced validation
        if (string.IsNullOrWhiteSpace(product.Description))
            return false;

        // Description length validation
        if (product.Description.Length < 10)
            return false;

        return true;
    }
}


