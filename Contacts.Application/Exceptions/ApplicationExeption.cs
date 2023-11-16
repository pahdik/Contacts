namespace Contacts.Application.Exceptions;

public class ApplicationException : Exception
{
    public ApplicationException(string message)
        : base(message)
    { }

    public ApplicationException(string message, int statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public int StatusCode { get; set; }
}
