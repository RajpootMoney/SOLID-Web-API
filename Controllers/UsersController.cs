using Microsoft.AspNetCore.Mvc;
using SOLIDWebAPI.Models;
using SOLIDWebAPI.Services;

namespace SOLIDWebAPI.Controllers;

/// <summary>
/// SINGLE RESPONSIBILITY PRINCIPLE (SRP):
/// This controller has ONE responsibility: Handle HTTP requests/responses for Users.
/// It doesn't contain business logic (delegated to IUserService) or data access (delegated to repositories).
/// 
/// DEPENDENCY INVERSION PRINCIPLE (DIP):
/// This controller depends on IUserService abstraction, not concrete implementation.
/// Dependencies are injected through constructor.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    // Constructor injection - DIP: Depend on abstractions
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// GET: api/users
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    /// <summary>
    /// GET: api/users/5
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    /// <summary>
    /// POST: api/users
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        try
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// PUT: api/users/5
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        try
        {
            var updatedUser = await _userService.UpdateUserAsync(id, user);
            
            if (updatedUser == null)
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
    /// DELETE: api/users/5
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}


