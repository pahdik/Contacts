using Contacts.Application.DTO.Contacts;
using Contacts.Web.Models;

namespace Contacts.Web.Extentions;

public static class ViewModelToDtoExtentions
{
    public static CreateContactDto ToCreateContactDto(this CreateContactViewModel viewModel)
    {
        return new CreateContactDto
        {
            Name = viewModel.Name,
            JobTitle = viewModel.JobTitle,
            MobilePhone = viewModel.MobilePhone,
            BirthDate = viewModel.BirthDate
        };
    }

    public static ContactDto ToContactDto(this UpdateContactViewModel viewModel)
    {
        return new ContactDto
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            JobTitle = viewModel.JobTitle,
            MobilePhone = viewModel.MobilePhone,
            BirthDate = viewModel.BirthDate
        };
    }
}
