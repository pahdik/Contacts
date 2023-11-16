using Contacts.Application.Mappings.Profiles;
using Contacts.Application.Services.Implementations;
using Contacts.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Application.Extentions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddScoped<IContactService, ContactService>();
        return service;
    }
    
    public static IServiceCollection AddProfiles(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(DtoToEntityProfile));
        service.AddAutoMapper(typeof(EntityToDtoProfile));
        return service;
    }
}
