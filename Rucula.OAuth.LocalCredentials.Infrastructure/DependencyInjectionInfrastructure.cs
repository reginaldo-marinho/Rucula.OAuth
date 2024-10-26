using Rucula.OAuth.LocalCredentials.Core.Auth;
using Rucula.OAuth.LocalCredentials.Core.Repositories;

using Rucula.OAuth.LocalCredentials.Infrastructure.Persistence;
using Rucula.OAuth.LocalCredentials.Infrastructure.Persistence.Repositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rucula.OAuth.LocalCredentials.Infrastructure;

public static class DependencyInjectionInfrastructure
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistence(configuration)
            .AddRepositories()
            .ResolveDependenciesIdentity()
            .ConfigureJWT();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DbContextProject>(options => options.UseSqlServer(connectionString));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuditProcessRepository, AuditProcessRepository>();

        return services;
    }

    public static IServiceCollection ResolveDependenciesIdentity(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<DbContextProject>()
        .AddDefaultTokenProviders();

        services.AddScoped<UserManager<IdentityUser>>();
        services.AddScoped<SignInManager<IdentityUser>>();

        return services;
    }

    public static IServiceCollection ConfigureJWT(this IServiceCollection services)
    {
        services.AddTransient<JsonWebToken>(); 

        
        services.AddScoped<IAuthRepository, AuthRepository>();

        return services;
    }

}
