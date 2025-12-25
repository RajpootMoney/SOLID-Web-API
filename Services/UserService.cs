using SOLIDWebAPI.Models;
using SOLIDWebAPI.Repositories;
using SOLIDWebAPI.Validators;

namespace SOLIDWebAPI.Services;

/// <summary>
/// SINGLE RESPONSIBILITY PRINCIPLE (SRP):
/// This class has ONE responsibility: Business logic for User operations.
/// It doesn't handle data access (delegated to IUserRepository) or validation (delegated to IValidator).
/// 
/// DEPENDENCY INVERSION PRINCIPLE (DIP):
/// This class depends on abstractions (IUserRepository, IValidator) not concrete implementations.
/// Dependencies are injected through constructor, making the class testable and flexible.
/// </summary>
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<User> _validator;

    // Constructor injection - DIP: Depend on abstractions
    public UserService(IUserRepository userRepository, IValidator<User> validator)
    {
        _userRepository = userRepository;
        _validator = validator;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        // Business logic: Simple retrieval, no transformation needed
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        // Business logic: Simple retrieval, no transformation needed
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> CreateUserAsync(User user)
    {
        // Business logic: Validate before creating
        if (!_validator.Validate(user))
        {
            throw new ArgumentException("User validation failed", nameof(user));
        }

        // Business logic: Set creation timestamp
        user.CreatedAt = DateTime.UtcNow;

        return await _userRepository.CreateAsync(user);
    }

    public async Task<User?> UpdateUserAsync(int id, User user)
    {
        // Business logic: Check if user exists
        if (!await _userRepository.ExistsAsync(id))
        {
            return null;
        }

        // Business logic: Validate before updating
        if (!_validator.Validate(user))
        {
            throw new ArgumentException("User validation failed", nameof(user));
        }

        return await _userRepository.UpdateAsync(id, user);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        // Business logic: Check if user exists before deletion
        if (!await _userRepository.ExistsAsync(id))
        {
            return false;
        }

        return await _userRepository.DeleteAsync(id);
    }
}


