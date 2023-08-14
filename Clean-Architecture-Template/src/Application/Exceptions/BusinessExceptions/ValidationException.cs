namespace Application.Exceptions.BusinessExceptions;

using System.Net;
using FluentValidation.Results;

public class ValidationException : BaseHttpException
{
    public ValidationException(List<ValidationFailure> messages) :
        base(
            message: "Unprocessable Entity",
            status: HttpStatusCode.UnprocessableEntity,
            bulkMessages: InitContext(messages: messages)
        )
    { }

    static private Dictionary<string, List<string>> InitContext(List<ValidationFailure> messages)
    {
        Dictionary<string, List<string>> initMessages = new();

        foreach (ValidationFailure error in messages)
        {
            if (!initMessages.ContainsKey(error.PropertyName))
            {
                initMessages[error.PropertyName] = new List<string>();
            }
            initMessages[error.PropertyName].Add(error.ErrorMessage);
        }

        return initMessages;
    }
}
