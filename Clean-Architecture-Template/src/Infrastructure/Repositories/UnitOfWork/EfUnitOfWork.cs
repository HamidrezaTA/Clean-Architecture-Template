using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Repositories.UnitOfWork;
using Infrastructure.Persistance.EFCore;

namespace Infrastructure.Repositories.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly SampleDbContext _dbContext;
        public ISampleRepository SampleRepository { get; set; }

        public EfUnitOfWork(SampleDbContext dbContext)
        {
            _dbContext = dbContext;

            SampleRepository = new SampleRepository(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}