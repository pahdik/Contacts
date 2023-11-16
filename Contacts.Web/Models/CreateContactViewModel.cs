namespace Contacts.Web.Models;

public class CreateContactViewModel
{
    public string Name { get; set; } = string.Empty;
    public string MobilePhone { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string BirthDate { get; set; } = string.Empty;
}
