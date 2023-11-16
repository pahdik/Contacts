using Contacts.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Web.Components;

public class ContactsListViewComponent : ViewComponent
{
    private readonly IContactService _contactService;
    public ContactsListViewComponent(IContactService contactService)
    {
        _contactService = contactService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var contacts = await _contactService.GetAllAsync();
        return View(contacts);
    }
}