using Contacts.Domain.Entities;
using Contacts.Domain.Repositories.Interfaces;
using Contacts.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastucture.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Contact> CreateAsync(Contact entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var contact = await _context.Contacts.AddAsync(entity);
        await _context.SaveChangesAsync();
        return contact.Entity;
    }

    public async Task DeleteAsync(Contact entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _context.Contacts.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<Contact>> GetAllAsync()
    {
        var contacts = await _context.Contacts.AsNoTracking().ToListAsync();
        return contacts;
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        var contact = await  _context.Contacts
            .FirstOrDefaultAsync(x => x.Id == id);
        return contact;
    }

    public async Task<Contact> UpdateAsync(Contact entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var contact = _context.Contacts.Update(entity);
        await _context.SaveChangesAsync();
        return contact.Entity;
    }
}
