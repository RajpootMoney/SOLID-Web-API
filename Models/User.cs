namespace SOLIDWebAPI.Models;

/// <summary>
/// SINGLE RESPONSIBILITY PRINCIPLE (SRP):
/// This class represents ONLY the User data structure.
/// It doesn't contain business logic, validation, or data access code.
/// </summary>
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

