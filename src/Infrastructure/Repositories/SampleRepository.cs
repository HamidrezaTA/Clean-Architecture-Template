using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistance.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SampleRepository : EFBaseRepository<Sample>, ISampleRepository
{
    public SampleRepository(SampleDbContext sampleDbContext) : base(sampleDbContext)
    {

    }
}