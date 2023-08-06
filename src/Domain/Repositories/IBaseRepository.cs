using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAsNoTracking();
        Task<T> GetByIdAsync(long id);
        Task AddAsync(T entity);
        void Update(T entity);
        Task SoftDeleteAsync(long id);
        Task HardDeleteAsync(long id);
    }
}