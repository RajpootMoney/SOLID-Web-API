using Microsoft.EntityFrameworkCore;
using SOLIDWebAPI.Data;
using SOLIDWebAPI.Models;
using SOLIDWebAPI.Repositories;
using SOLIDWebAPI.Services;
using SOLIDWebAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure SQLite Database
// DEPENDENCY INVERSION PRINCIPLE (DIP): We depend on abstractions (DbContext) not concrete implementations
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=solid_demo.db")
);

// Register repositories - DIP: Depend on interfaces, not concrete classes
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register services - DIP: Services depend on repository interfaces
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Register validators - DIP: Validation logic separated into its own service
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Create database and seed with sample data on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();

    // Seed the database with sample data
    DatabaseSeeder.Seed(dbContext);
}

app.Run();
