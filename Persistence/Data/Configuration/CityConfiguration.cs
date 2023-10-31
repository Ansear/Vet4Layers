using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration;
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

            builder.HasOne(c => c.Departaments).WithMany(c => c.Cities).HasForeignKey(c => c.IdDePartament);
        }
    }