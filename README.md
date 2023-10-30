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

```

```


