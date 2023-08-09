namespace Application.Exceptions;

using System;
using System.Net;

public class BaseHttpException : Exception
{
    public int Status { get; private set; }

    public BaseHttpException(string message, HttpStatusCode status) : base(message)
    {
        Status = (int)status;
    }
}
