using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id);

        builder.Property(u => u.UserName).HasColumnName("UserName").HasColumnType("varchar").HasMaxLength(50);

        builder.Property(u => u.Email).HasColumnName("email").HasColumnType("varchar").HasMaxLength(100).IsRequired();

        builder.Property(u => u.Password).HasColumnName("password").HasColumnType("varchar").HasMaxLength(255).IsRequired();

        builder.HasMany(p => p.Rols).WithMany(r => r.Users).UsingEntity<UserRol>(

            j => j.HasOne(pt => pt.Rol).WithMany(t => t.UserRols).HasForeignKey(ut => ut.IdRol),

            j => j.HasOne(et => et.User).WithMany(et => et.UsersRols).HasForeignKey(el => el.IdUser),

            j =>
            {
                j.ToTable("userRol");
                j.HasKey(t => new { t.IdUser, t.IdRol });
            });

        builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        builder.HasOne(u => u.Client).WithOne(u => u.User).HasForeignKey<User>(u => u.IdClient);
    }
}