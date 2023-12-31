using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class CustomerPhoneConfiguration : IEntityTypeConfiguration<CustomerPhone>
    {
        public void Configure(EntityTypeBuilder<CustomerPhone> builder)
        {
            builder.ToTable("CustomerPhone");

            builder.HasKey(cp => cp.Id);
            builder.Property(cp => cp.Id);

            builder.Property(cp => cp.Number).IsRequired().HasMaxLength(50);

            builder.HasOne(cp => cp.Clients).WithMany(c => c.CustomerPhones).HasForeignKey(cp => cp.IdClient);
        }
    }