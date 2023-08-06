using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        ISampleRepository SampleRepository { get; set; }

        Task<int> SaveChangesAsync();
    }
}