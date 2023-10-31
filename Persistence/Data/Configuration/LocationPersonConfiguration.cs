using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class LocationPersonConfiguration : IEntityTypeConfiguration<LocationPerson>
{
    public void Configure(EntityTypeBuilder<LocationPerson> builder)
    {
        builder.ToTable("LocationPerson");

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id);

        builder.Property(l => l.TypeRoad);

        builder.Property(l => l.MainNumber);

        builder.Property(l => l.MainLetter);

        builder.Property(l => l.Bis).HasMaxLength(3);

        builder.Property(l => l.SecondaryLetter).HasMaxLength(3);

        builder.Property(l => l.CardinalPrimary).HasMaxLength(10);

        builder.Property(l => l.SecondNumber).HasColumnType("int");

        builder.Property(l => l.TertaryLetter).HasMaxLength(10);

        builder.Property(l => l.TertaryNumber).HasColumnType("int");

        builder.Property(l => l.CardinalSecondary).HasMaxLength(10);

        builder.Property(l => l.Complement).HasMaxLength(50);

        builder.Property(l => l.ZipCode).HasMaxLength(10);

        builder.HasOne(l => l.Clients).WithOne(l => l.LocationPerson).HasForeignKey<LocationPerson>(l => l.IdClient);

        builder.HasOne(l => l.Cities).WithOne(l => l.LocationPerson).HasForeignKey<LocationPerson>(l => l.IdCiudad);
    }
}