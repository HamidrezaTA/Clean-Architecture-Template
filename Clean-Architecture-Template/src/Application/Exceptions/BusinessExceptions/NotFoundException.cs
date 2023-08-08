namespace Application.Exceptions.BusinessExceptions;

using System.Net;

public class NotFoundException : BaseHttpException
{
    public NotFoundException() : base(message: "Data not found!", status: HttpStatusCode.NotFound)
    { }

    public NotFoundException(string message) : base(message: message, status: HttpStatusCode.NotFound)
    { }
}
