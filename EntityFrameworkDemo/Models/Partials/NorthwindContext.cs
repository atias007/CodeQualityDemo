using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkDemo.Models;

// https://learn.microsoft.com/en-us/ef/core/querying/filters
public partial class NorthwindContext
{
    private readonly string _tenancy;

    public NorthwindContext(string tenancy)
    {
        _tenancy = tenancy;
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasQueryFilter(c => c.City == _tenancy);

        modelBuilder.HasSequence<int>("HiLoSequence").IncrementsBy(100);

        modelBuilder.Entity<HiLoDemo>()
            .Property(h => h.Id)
            .UseHiLo("HiLoSequence");
    }
}