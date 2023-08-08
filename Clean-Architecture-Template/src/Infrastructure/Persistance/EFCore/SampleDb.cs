namespace Infrastructure.Persistance.EFCore;

using System;
using Application.DbTransaction;

public class SampleDb : ISampleDb
{
    private readonly SampleDbContext _dbContext;

    public SampleDb(SampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Transaction(Func<Task> action)
    {
        using var transaction = _dbContext.Database.BeginTransaction();

        try
        {
            await action.Invoke();
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
