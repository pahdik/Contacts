using Contacts.Domain.Repositories.Interfaces;
using Contacts.Infrastucture.Data;
using Contacts.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Infrastucture.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDatabaseConnection(this IServiceCollection service, string? connectionString)
    {
        ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));
        service.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                    connectionString, b => b.MigrationsAssembly("Contacts.Infrastucture")));

        return service;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IContactRepository, ContactRepository>();
        return service;
    }
}
