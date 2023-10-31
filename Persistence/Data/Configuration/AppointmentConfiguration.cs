using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointment");

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id);

        builder.Property(a => a.Date).IsRequired().HasColumnType("date");

        builder.Property(a => a.Time).IsRequired().HasColumnType("time");
        
        builder.HasOne(c => c.Clients).WithMany(c => c.Appointments).HasForeignKey(c => c.IdClient).IsRequired();

        builder.HasOne(c => c.Services).WithMany(c => c.Appointments).HasForeignKey(c => c.IdService).IsRequired();

        builder.HasOne(c => c.Pets).WithMany(c => c.Appointments).HasForeignKey(c => c.IdPet).IsRequired();
    }
}