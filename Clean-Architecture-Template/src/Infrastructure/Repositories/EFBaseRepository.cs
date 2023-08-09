using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistance.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EFBaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;

        public EFBaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public EFBaseRepository(SampleDbContext sampleDbContext)
        {
            _dbSet = sampleDbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable<T>();
        }

        public IQueryable<T> GetAsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task HardDeleteAsync(long id)
        {
            var link = await _dbSet.FindAsync(id);
            if (link is not null)
                _dbSet.Remove(link);
        }

        public async Task SoftDeleteAsync(long id)
        {
            var link = await _dbSet.FindAsync(id);
            if (link is not null)
            {
                link.ModifiedDate = DateTimeOffset.Now;
                link.IsDeleted = true;
            }
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}