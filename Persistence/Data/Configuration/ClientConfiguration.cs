using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration;
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id);

            builder.Property(c => c.Name):IsRequired().HasMaxLength(50);
            
            builder.Property(c => c.LastName):IsRequired().HasMaxLength(50);
            
            builder.Property(c => c.Email):IsRequired().HasMaxLength(80);
        }
    }