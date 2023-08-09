namespace Application.Exceptions.RuntimeExceptions;

using Application.Exceptions;

public class ConnectionStringException : RuntimeException
{
    public ConnectionStringException() : base(message: "Please check the appSettings. The connectionString is not registered.")
    { }
}
