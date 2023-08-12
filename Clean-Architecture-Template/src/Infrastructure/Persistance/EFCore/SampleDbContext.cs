namespace Infrastructure.Persistance.EFCore;

using Domain.Entities;
using Infrastructure.Persistance.FluentAPIs;
using Microsoft.EntityFrameworkCore;

public class SampleDbContext : DbContext
{
    public required DbSet<Sample> Samples { get; set; }

    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new SampleConfiguration());

        base.OnModelCreating(builder);
    }
}
