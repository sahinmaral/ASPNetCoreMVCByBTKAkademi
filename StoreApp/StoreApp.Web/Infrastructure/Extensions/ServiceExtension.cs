using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entities;
using StoreApp.Repositories;
using StoreApp.Repositories.Abstract;
using StoreApp.Services;
using StoreApp.Services.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Infrastructure.Extensions;

public static class ServiceExtension
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StoreAppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SQLServerDbConnection"), b => b.MigrationsAssembly("StoreApp.Web"));

            options.EnableSensitiveDataLogging(true);
        });
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<StoreAppDbContext>();
    }

    public static void ConfigureSession(this IServiceCollection services)
    {
        services.AddScoped<Cart>(serviceProvider => SessionCart.GetCart(serviceProvider));

        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.Cookie.Name = "StoreApp.Session";
            options.IdleTimeout = TimeSpan.FromHours(3);
        });
    }

    public static void ConfigureRepositoryRegistration(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }

    public static void ConfigureServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IAuthService, AuthManager>();
    }

    public static void ConfigureLocalization(this IServiceCollection services)
    {
        CultureInfo[] supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("tr-TR")
        };

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("tr-TR", "tr-TR");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            options.RequestCultureProviders = new List<IRequestCultureProvider>
            {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
            };
        });
    }

    public static void ConfigureRouting(this IServiceCollection services)
    {
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });
    }

    public static void ConfigureApplicationCookie(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options => {
            options.ExpireTimeSpan = TimeSpan.FromHours(3);
        });
    }
}