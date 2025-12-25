using SOLIDWebAPI.Models;

namespace SOLIDWebAPI.Validators;

/// <summary>
/// SINGLE RESPONSIBILITY PRINCIPLE (SRP):
/// This class has ONE responsibility: Validating User entities.
/// It doesn't handle business logic, data access, or presentation.
/// 
/// OPEN/CLOSED PRINCIPLE (OCP):
/// This class is open for extension (you can inherit and add more validation rules)
/// but closed for modification (existing validation logic doesn't need to change).
/// 
/// LISKOV SUBSTITUTION PRINCIPLE (LSP):
/// This class can be substituted for any IValidator<User> without breaking functionality.
/// Any code expecting IValidator<User> will work correctly with this implementation.
/// </summary>
public class UserValidator : IValidator<User>
{
    public bool Validate(User user)
    {
        if (user == null)
            return false;

        // Validation rules for User
        if (string.IsNullOrWhiteSpace(user.Name))
            return false;

        if (string.IsNullOrWhiteSpace(user.Email))
            return false;

        // Basic email validation
        if (!user.Email.Contains('@') || !user.Email.Contains('.'))
            return false;

        // Name length validation
        if (user.Name.Length < 2 || user.Name.Length > 100)
            return false;

        return true;
    }
}


