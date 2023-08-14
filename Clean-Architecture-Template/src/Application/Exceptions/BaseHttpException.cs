namespace Application.Exceptions;

using System;
using System.Net;

public class BaseHttpException : Exception
{
    public int Status { get; private set; }
    public Dictionary<string, List<string>>? BulkMessages { get; private set; }

    public BaseHttpException(string message, HttpStatusCode status, Dictionary<string, List<string>>? bulkMessages = null) : base(message)
    {
        Status = (int)status;
        BulkMessages = bulkMessages;
    }
}
