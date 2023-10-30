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
    DbSet<Brand> Brands { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<ContactPerson> ContactPeople { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<Departament> Departaments { get; set; }
    DbSet<DetailMovementInventory> DetailMovementInventories { get; set; }
    DbSet<Inventory> Inventories { get; set; }
    DbSet<Invoice> Invoices { get; set; }
    DbSet<LocationPerson> LocationPeople { get; set; }
    DbSet<MovementInventory> MovementInventories { get; set; }
    DbSet<PaymentForm> PaymentForms { get; set; }
    DbSet<Person> People { get; set; }
    DbSet<Presentation> Presentations { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<RolPerson> RolPeople { get; set; }
    DbSet<TypeContact> TypeContacts { get; set; }
    DbSet<TypeDocument> TypeDocuments { get; set; }
    DbSet<TypeMovementInventory> TypeMovementInventories { get; set; }
    DbSet<TypePerson> TypePeople { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}