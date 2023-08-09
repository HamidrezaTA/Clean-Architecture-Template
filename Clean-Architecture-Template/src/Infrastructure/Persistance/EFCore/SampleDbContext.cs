﻿namespace Infrastructure.Persistance.EFCore;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class SampleDbContext : DbContext
{
    public required DbSet<Sample> Samples { get; set; }

    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Sample>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasQueryFilter(f => !f.IsDeleted);
        });
    }
}
