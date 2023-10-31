using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pet");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

        builder.Property(p => p.Specie).IsRequired();

        builder.Property(p => p.DateOfBirth).IsRequired().HasColumnType("date");

        builder.HasOne(p => p.Breeds).WithMany(p => p.Pets).HasForeignKey(p => p.IdBreed);

        builder.HasOne(p => p.Clients).WithMany(p => p.Pets).HasForeignKey(p => p.IdClient);
    }
}