namespace SOLIDWebAPI.Validators;

/// <summary>
/// OPEN/CLOSED PRINCIPLE (OCP):
/// This interface is open for extension (you can create new validator implementations)
/// but closed for modification (existing code doesn't need to change when new validators are added).
/// 
/// INTERFACE SEGREGATION PRINCIPLE (ISP):
/// This is a focused interface with a single responsibility: validation.
/// It doesn't force implementers to implement unrelated methods.
/// 
/// DEPENDENCY INVERSION PRINCIPLE (DIP):
/// Services depend on this abstraction, allowing different validation strategies to be used.
/// </summary>
/// <typeparam name="T">The type of entity to validate</typeparam>
public interface IValidator<in T>
{
    /// <summary>
    /// Validates an entity and returns true if valid, false otherwise.
    /// </summary>
    bool Validate(T entity);
}


