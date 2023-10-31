using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Service");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id);

        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);

        builder.Property(s => s.Price).IsRequired().HasColumnType("decimal");
    }
}