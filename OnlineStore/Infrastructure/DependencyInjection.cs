using Application.Abstractions.Services.ShopServices;
using Application.Abstractions.Services.ShopServices.HandlerServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.Abstractions.Services.UserServices;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services.ShopServices;
using Infrastructure.Services.ShopServices.HandlerServices;
using Infrastructure.Services.ShopServices.ValidationServices;
using Infrastructure.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Db Context
        services.AddDbContext<OnlineStoreDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("OnlineStoreDbConnection")));

        // Repositories
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ICartItemRepository, CartItemRepository>();

        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        
        // Services
        services.AddScoped<IProductHandlerService, ProductHandlerService>();
        services.AddScoped<IProductValidationService, ProductValidationService>();
        
        services.AddScoped<IUserAuthValidationService, UserAuthValidationService>();
        services.AddScoped<IUserAuthService, UserAuthService>();

        services.AddScoped<ICartItemValidationService, CartItemValidationService>();

        services.AddScoped<IPurchaseHandlerService, PurchaseHandlerService>();
        services.AddScoped<IPurchaseValidationService, PurchaseValidationService>();

        return services;
    }
}