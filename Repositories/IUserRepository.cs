using SOLIDWebAPI.Models;

namespace SOLIDWebAPI.Repositories;

/// <summary>
/// INTERFACE SEGREGATION PRINCIPLE (ISP):
/// This interface contains ONLY methods related to User operations.
/// It doesn't force implementers to implement Product-related methods.
/// 
/// DEPENDENCY INVERSION PRINCIPLE (DIP):
/// High-level modules (Services) depend on this abstraction, not concrete implementations.
/// </summary>
public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task<User?> UpdateAsync(int id, User user);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}

