using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;
public class Vet4Context : DbContext
{
    public Vet4Context(DbContextOptions options) : base(options)
    {
    }
    DbSet<City> Cities { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<Departament> Departaments { get; set; }
    DbSet<LocationPerson> LocationPeople { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}