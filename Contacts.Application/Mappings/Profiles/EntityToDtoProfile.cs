using AutoMapper;
using Contacts.Application.DTO.Contacts;
using Contacts.Domain.Entities;

namespace Contacts.Application.Mappings.Profiles;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        CreateMap<Contact, ContactDto>()
         .ForMember(d => d.BirthDate, o => o.MapFrom(src => src.BirthDate.ToString()));
    }
}
