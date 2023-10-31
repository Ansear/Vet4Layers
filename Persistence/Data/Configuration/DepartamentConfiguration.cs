using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
{
    public void Configure(EntityTypeBuilder<Departament> builder)
    {
        builder.ToTable("Departament");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
        
        builder.HasOne(d => d.Countries).WithMany(d => d.Departaments).HasForeignKey(d => d.IdCountry);
    }
}