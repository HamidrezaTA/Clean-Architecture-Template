using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.EFCore
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {

        }

        public DbSet<Sample> Samples { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sample>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasQueryFilter(f => !f.IsDeleted);
            });
        }

    }
}
