namespace Application.DbTransaction;

using System;

public interface ISampleDb
{
    Task Transaction(Func<Task> action);
}
