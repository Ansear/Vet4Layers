# Vet4Layers

## Paquetes

### WebApi

- AspNetCoreRateLimit 

- AutoMapper.Extensions.Microsoft.DependencyInjection

- Microsoft.AspNetCore.Authentication.JwtBearer

- Microsoft.AspNetCore.Mvc.Versioning

- Microsoft.AspNetCore.OpenApi

- Microsoft.EntityFrameworkCore.Design

- System.IdentityModel.Tokens.Jwt

### Dominio

- FluentValidation.AspNetCore

- itext7.pdfhtml

- Microsoft.EntityFrameworkCore

### Persistencia

- Microsoft.EntityFrameworkCore

- Pomelo.EntityFrameworkCore.MySql

## Conexion Base Datos

```
"ConnectionStrings": {
    "MySqlConex" : "server=localhost;user=root;password=123456;database=DataBaseName"
  }
```

## Crear Contexto

Ruta = Persistence -> Data -> FileContext.cs

```
public class Vet4Context : DbContext
{
    public Vet4Context(DbContextOptions options) : base(options)
    {
    }
    DbSet<City> Cities { get; set; }
    DbSet<Country> Countries { get; set; }
    (Poner todas las entidades....)
    DbSet<Departament> Departaments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
```

## Inyectar el Contexto en el Program.cs

Ruta = WebApi -> Program.cs
Colocar antes del app = builder.Build();

```
builder.Services.AddDbContext<Vet4Context>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySqlConex");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
```

## Creacion Entidades

En el proyecto Dominio -> Carpeta Entities

- Country

```
public class Country : BaseEntity
{    public string Name { get; set; }
    public ICollection<Departament> Departaments { get; set; }
}
```

- Departament

```
public class Departament : BaseEntity
{
    public string Name { get; set; }
    public int IdCountry { get; set; }
    public Country Countries { get; set; }
    public ICollection<City> Cities { get; set; }
}
```

## Creacion Archivos Configuracion

Ruta = Persistencia -> Data -> Configuration

### CityConfiguration

```
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
```

### RefreshTokenConfiguration

```
public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshToken");
    }
```

### UserConfiguration

```
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
    }
```

### RolConfiguration

```
public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Rol");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);

        builder.Property(p => p.Name).HasColumnName("rolName").HasColumnType("varchar").HasMaxLength(50).IsRequired();
    }
```
