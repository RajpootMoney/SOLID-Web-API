# SOLID Principles WebAPI Project

This project demonstrates all five SOLID principles in a .NET WebAPI application with SQLite database.

## SOLID Principles Explained

### 1. **Single Responsibility Principle (SRP)**
**"A class should have only one reason to change."**

**Examples in this project:**
- `UserRepository`: Only handles data access for users
- `UserService`: Only handles business logic for users
- `UserValidator`: Only handles validation for users
- `UsersController`: Only handles HTTP requests/responses

**Why it matters:** Each class has a single, well-defined purpose, making the code easier to understand, test, and maintain.

### 2. **Open/Closed Principle (OCP)**
**"Software entities should be open for extension but closed for modification."**

**Examples in this project:**
- `IValidator<T>` interface: You can create new validators (like `AdvancedProductValidator`) without modifying existing code
- `AdvancedProductValidator`: Extends validation without changing `ProductValidator`

**Why it matters:** You can add new features by creating new classes instead of modifying existing ones, reducing the risk of breaking existing functionality.

### 3. **Liskov Substitution Principle (LSP)**
**"Objects of a superclass should be replaceable with objects of its subclasses without breaking the application."**

**Examples in this project:**
- `UserValidator` and `AdvancedProductValidator` can be substituted anywhere `IValidator<T>` is expected
- Any implementation of `IUserRepository` can replace `UserRepository` without breaking the code

**Why it matters:** Ensures that derived classes maintain the contract of their base classes/interfaces, making the code more reliable and predictable.

### 4. **Interface Segregation Principle (ISP)**
**"Clients should not be forced to depend on interfaces they do not use."**

**Examples in this project:**
- `IUserRepository`: Contains only user-related methods
- `IProductRepository`: Contains only product-related methods
- `IValidator<T>`: A focused interface with a single responsibility

**Why it matters:** Prevents classes from implementing methods they don't need, keeping interfaces focused and implementations clean.

### 5. **Dependency Inversion Principle (DIP)**
**"High-level modules should not depend on low-level modules. Both should depend on abstractions."**

**Examples in this project:**
- Controllers depend on `IUserService` and `IProductService` (abstractions), not concrete classes
- Services depend on `IUserRepository` and `IProductRepository` (abstractions)
- Services depend on `IValidator<T>` (abstraction) for validation

**Why it matters:** Makes the code more flexible, testable, and maintainable. You can easily swap implementations (e.g., use a mock repository for testing).

## Project Structure

```
SOLIDWebAPI/
├── Controllers/          # HTTP request handlers (SRP, DIP)
├── Data/                 # Database context (SRP)
├── Models/               # Data models (SRP)
├── Repositories/         # Data access layer (SRP, ISP, DIP)
├── Services/             # Business logic layer (SRP, DIP)
├── Validators/           # Validation logic (SRP, OCP, LSP, ISP, DIP)
└── Program.cs            # Application startup and DI configuration
```

## How to Run

1. **Restore packages:**
   ```bash
   dotnet restore
   ```

2. **Run the application:**
   ```bash
   dotnet run
   ```

3. **Access Swagger UI:**
   Navigate to `https://localhost:5001/swagger` (or the port shown in the console)

## API Endpoints

### Users
- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create a new user
- `PUT /api/users/{id}` - Update a user
- `DELETE /api/users/{id}` - Delete a user

### Products
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `GET /api/products/price-range?minPrice=10&maxPrice=100` - Get products by price range
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product

## Example Requests

### Create a User
```json
POST /api/users
{
  "name": "John Doe",
  "email": "john.doe@example.com"
}
```

### Create a Product
```json
POST /api/products
{
  "name": "Laptop",
  "price": 999.99,
  "description": "High-performance laptop"
}
```

## Database

The application uses SQLite with a database file `solid_demo.db` that is automatically created on first run.

## Key Takeaways

1. **Separation of Concerns**: Each layer has a specific responsibility
2. **Dependency Injection**: All dependencies are injected through constructors
3. **Interface-Based Design**: Code depends on abstractions, not concrete implementations
4. **Extensibility**: New features can be added without modifying existing code
5. **Testability**: The architecture makes unit testing easy with mock dependencies


