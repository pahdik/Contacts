using Contacts.Application.DTO.Contacts;

namespace Contacts.Application.Services.Interfaces;

public interface IContactService
{
    Task<ContactDto> GetContactByIdAsync(int id);
    Task<ContactDto> CreateContactAsync(CreateContactDto model);
    Task<ContactDto> UpdateContactAsync(ContactDto model);
    Task DeleteContactAsync(int id);
    Task<IList<ContactDto>> GetAllAsync();
}
