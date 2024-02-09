using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Presentation.Middlewares;
using Presentation.Profiles;
using Swashbuckle.AspNetCore.Filters;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<string>();

// Default
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Custom and installed
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddScoped<ExceptionHandlingMiddleware>();

// builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();