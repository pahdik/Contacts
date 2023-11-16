using AutoMapper;
using Contacts.Application.DTO.Contacts;
using Contacts.Application.Services.Interfaces;
using Contacts.Domain.Entities;
using Contacts.Domain.Repositories.Interfaces;
using System.Net;
using ApplicationException = Contacts.Application.Exceptions.ApplicationException;


namespace Contacts.Application.Services.Implementations;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    
    public ContactService(IMapper mapper, IContactRepository contactRepository)
    {
        _mapper = mapper;
        _contactRepository = contactRepository;
    }

    public async Task<ContactDto> CreateContactAsync(CreateContactDto model)
    {
        var contact = _mapper.Map<CreateContactDto, Contact>(model);

        var created = await _contactRepository.CreateAsync(contact);
        var fullContactInfo = await _contactRepository.GetByIdAsync(created.Id);
        var mappedContact = _mapper.Map<Contact, ContactDto>(fullContactInfo);
        return mappedContact;
    }

    public async Task DeleteContactAsync(int id)
    {
        var contact = await _contactRepository.GetByIdAsync(id);
        if (contact is null)
        {
            throw new ApplicationException(
                $"Contact with id <{id}> is not found.",
                (int)HttpStatusCode.BadRequest);
        }
        await _contactRepository.DeleteAsync(contact);
    }

    public async Task<IList<ContactDto>> GetAllAsync()
    {
        var contacts = await _contactRepository.GetAllAsync();
        if (contacts is null)
        {
            throw new ApplicationException(
                $"Contacts are not found.",
                (int)HttpStatusCode.NoContent);
        }

        var mappedContacts = _mapper.Map<IList<Contact>, IList<ContactDto>>(contacts);
        return mappedContacts;
    }

    public async Task<ContactDto> GetContactByIdAsync(int id)
    {
        var contact = await _contactRepository.GetByIdAsync(id);
        if (contact is null)
        {
            throw new ApplicationException(
                $"Contact with id <{id}> is not found.",
                (int)HttpStatusCode.NoContent);
        }
        var mappedContact = _mapper.Map<Contact,ContactDto>(contact);
        return mappedContact;
    }

    public async Task<ContactDto> UpdateContactAsync(ContactDto model)
    {
        var existingContact = await _contactRepository.GetByIdAsync(model.Id);
        if (existingContact is null)
        {
            throw new ApplicationException(
                $"User with id <{model.Id}> is not found.",
                (int)HttpStatusCode.BadRequest);
        }

        _mapper.Map(model, existingContact);

        var updated = await _contactRepository.UpdateAsync(existingContact);
        var fullContactInfo = await _contactRepository.GetByIdAsync(updated.Id);
        var mappedContact = _mapper.Map<Contact, ContactDto>(fullContactInfo);
        return mappedContact;

    }
}
