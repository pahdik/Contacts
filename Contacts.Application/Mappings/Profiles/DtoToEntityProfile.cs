using AutoMapper;
using Contacts.Application.DTO.Contacts;
using Contacts.Domain.Entities;

namespace Contacts.Application.Mappings.Profiles;

public class DtoToEntityProfile : Profile
{
    public DtoToEntityProfile() 
    {
        CreateMap<ContactDto, Contact>()
         .ForMember(d => d.BirthDate, o => o.MapFrom(src => DateTime.Parse(src.BirthDate, System.Globalization.CultureInfo.InvariantCulture)));
        CreateMap<CreateContactDto, Contact>()
         .ForMember(d => d.BirthDate, o => o.MapFrom(src => DateTime.Parse(src.BirthDate, System.Globalization.CultureInfo.InvariantCulture)));
    }
}
