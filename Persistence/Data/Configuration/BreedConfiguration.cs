using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration;
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("Breed");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id);

            builder.Property(b => b.BreedName).IsRequired().HasMaxLength(50);
        }
    }