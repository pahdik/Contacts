using Contacts.Application.Services.Interfaces;
using Contacts.Web.Extentions;
using Contacts.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Web.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddContact(CreateContactViewModel model)
        {
            var createdContact = await _contactService.CreateContactAsync(model.ToCreateContactDto());
            return Ok(createdContact);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContact(UpdateContactViewModel model)
        {
            var updatedContact = await _contactService.UpdateContactAsync(model.ToContactDto());
            return Ok(updatedContact);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContactAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> GetContactById(int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            return Ok(contact);
        }
    }
}