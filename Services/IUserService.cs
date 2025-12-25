using SOLIDWebAPI.Models;

namespace SOLIDWebAPI.Services;

/// <summary>
/// DEPENDENCY INVERSION PRINCIPLE (DIP):
/// High-level modules (Controllers) depend on this abstraction, not concrete implementations.
/// This allows for easy testing and swapping implementations.
/// </summary>
public interface IUserService
{
    Task<User?> GetUserByIdAsync(int id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> CreateUserAsync(User user);
    Task<User?> UpdateUserAsync(int id, User user);
    Task<bool> DeleteUserAsync(int id);
}


