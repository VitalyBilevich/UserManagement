using UserManagement.Infrastructure.Extensions;
using UserManagement.Application.Extensions;
using UserManagement.Application.Validation;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var configurationValidationResult = ConfigurationValidator.ValidateRepositoryType(configuration);
if (!configurationValidationResult.IsValid)
{
    Console.WriteLine($"Configuration Error: {configurationValidationResult.ErrorMessage}");
    return;
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Infrastructure and Application services inside the API Layer (Presentation Layer).
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();
