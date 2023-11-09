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

```csharp
"ConnectionStrings": {
    "MySqlConex" : "server=localhost;user=root;password=123456;database=DataBaseName"
  }
```

## Crear Contexto

- Ruta = Persistence -> Data -> FileContext.cs

```csharp
public class Vet4Context : DbContext
{
    public Vet4Context(DbContextOptions options) : base(options)
    {
    }
    Public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
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

- Ruta = WebApi -> Program.cs
  Colocar antes del app = builder.Build();

```csharp
builder.Services.AddDbContext<Vet4Context>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySqlConex");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
```

## Creacion Entidades

- Ruta -> Dominio -> Carpeta Entities

- Country

```csharp
public class Country : BaseEntity
{    public string Name { get; set; }
    public ICollection<Departament> Departaments { get; set; }
}
```

- Departament

```csharp
public class Departament : BaseEntity
{
    public string Name { get; set; }
    public int IdCountry { get; set; }
    public Country Countries { get; set; }
    public ICollection<City> Cities { get; set; }
}
```

## Creacion Archivos Configuracion

- Ruta = Persistencia -> Data -> Configuration

### CityConfiguration

```csharp
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

```csharp
public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshToken");
    }
```

### UserConfiguration

```csharp
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

```csharp
public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Rol");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);

        builder.Property(p => p.Name).HasColumnName("rolName").HasColumnType("varchar").HasMaxLength(50).IsRequired();
    }
```

## Migracion

## Crear La Migracion

```powershell
dotnet ef migrations add InitialCreated --project .\Persistence\ --startup-project .\WebApi\ --output-dir ./Data/Migrations
```

## Volcar La Migracion En La Base De Datos

```powershell
dotnet ef database update --project .\Persistence\ --startup-project .\WebApi\
```

## Creacion BaseApiController

- Ruta = WebApi-> Controllers-> *Todos los Controladores...*

```csharp
namespace WebApi.Controllers;
[ApiController]
[Route("vet/api/[controller]")]
public class BaseApiController : ControllerBase
{

}
```

## Crear Metodos De Extensión

Los metodos de extension permiten agregar nuevos metodos a tipos Existentes sin modificar el Original. Permite extender la funcionalidad de las clases y tipos sin necesidad de clases y tipos sin necesidad de implementar herencia.

Ruta = WebApi -> "Extensions" **Crear carpeta *Extensions*** ->  Crear Clase **_ApplicationServiceExtensions_** _Esta Clase Debe ser Estatica_

```csharp

namespace WebApi.Extensions;
public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>//Permitir cualquier Origen de Peticion
    services.AddCors(Options =>
    {
        Options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin() //WithOrigins("http://dominio.com")
            .AllowAnyMethod()        //WithMethods("GET","POST")
            .AllowAnyHeader()        //WithHeaders("Accept","content-type")
        );
    });
}
```

## Inyectar El Servicio En El program.cs

Debajo de **_builder.Services.AddSwaggerGen();_**

```csharp
builder.Services.ConfigureCors();

....

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy"); 
```

## Unidad De Trabajo

Patron de diseño que permite agrupar una o mas operaciones (Creación, Lectura, Actualización y Eliminación) En una unica transacción.

### Interface Repositorio Generico

- Ruta = Domain -> Crear Carpeta **_Interfaces_** -> Crear **Interface** **_IGenericRepository_**

```csharp
namespace Domain.Interfaces;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
}
```

### Repositorio Generico

- Ruta = Application -> Crear Carpeta **_Repository_** -> Crear **Clase** **_GenericRespository_**

```csharp
namespace Application.Repository;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly Vet4Context _context;

    public GenericRepository(Vet4Context context)
    {
        _context = context;
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }


    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
```

### Interface Clases

Crear La Interface Respectiva para cada clase

- Ruta -> Domain -> Interfaces -> Crear **_Interface_**

```csharp
namespace Domain.Interfaces;
public interface ICountry : IGenericRepository<Country>
{

}

```

- Interface **IUserRepository**
  
  ```csharp
  namespace Domain.Interfaces;
  public interface IUserRepository : IGenericRepository<User>
  {
      Task<User> GetByUsernameAsync(string username);
      Task<User> GetByRefreshTokenAsync(string username);
  }
  ```

### Implementar Interfaces En El Repositorio Respectivo

- Ruta = Application-> Repository -> Crear **_Repositorio_**
  
  - CountryRepository
    
    ```csharp
    namespace Application.Repository;
    public class CountryRepository : GenericRepository<Country>, ICountry
    {
        private readonly Vet4Context _context;
        public CountryRepository(Vet4Context context) : base(context)
        {
            _context = context;
        }
    }
    ```
  
  - UserRepository
    
    ```csharp
    namespace Application.Repository;
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly Vet4Context _context;
    
        public UserRepository(Vet4Context context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users
                .Include(u => u.Rols)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }
    
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Rols)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
        }
    }
    ```

### Crear Unidad De Trabajo (UnitOfWork)

- Ruta = Domain -> Interface -> IUnitOfWork
  
  - IUnitOfWork
    
    ```csharp
    namespace Domain.Interfaces;
    public interface IUnitOfWork
    {
        ICity Cities { get; }
        IClient Clients { get; }
        IDepartament Departaments { get; }
        ICountry Countries { get; }
        ...Todas las entidades   
        Task<int> SaveAsync();
    }
    ```

### Implementar La Interface IUnitOfWork En UnitOfWork

- Ruta = Application -> UnitOfWork -> Clase **UnitOfWork**
  
  ```csharp
  namespace Application.UnitOfWork;
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
      private readonly Vet4Context _context;
      private IAppointment _appointments;
      private IBreed _breeds;
      private ICity _cities;
      private IClient _clients;
      private ICountry _countries;
      private ICustomerPhone _customerPhones;
      private IDepartament _departaments;
      private ILocationPerson _locationPersons;
      private IPet _pets;
      private IRolRepository _roles;
      private IUserRepository _users;
      private IService _services;
      public UnitOfWork(Vet4Context context)
      {
          _context = context;
      }
  
      public ICity Cities
      {
          get
          {
              _cities ??= new CityRepository(_context);
              return _cities;
          }
      }
      ...Implementar Todas las interfaces
      public Task<int> SaveAsync()
      {
          return _context.SaveChangesAsync();
      }
  
      public void Dispose()
      {
          _context.Dispose();
      }
  }
  ```

### Implementar La Unidad De Trabajo En El Metodo De Extension

- Ruta = WebApi -> Extensions -> **_ApplicationServiceExtension_**
  
  ```csharp
  namespace WebApi.Extensions;
  public static class ApplicationServiceExtension
  {
      public static void ConfigureCors(this IServiceCollection services) =>//Permitir cualquier Origen de Peticion
      services.AddCors(Options =>
      {
          Options.AddPolicy("CorsPolicy", builder =>
              builder.AllowAnyOrigin() //WithOrigins("http://dominio.com")
              .AllowAnyMethod()        //WithMethods("GET","POST")
              .AllowAnyHeader()        //WithHeaders("Accept","content-type")
          );
      });
      public static void AddApplicationServices(this IServiceCollection services)
      {
          services.AddScoped<IUnitOfWork, UnitOfWork>();
      }
  }
  ```
  
  

## Dtos (Data Transfer Object)

Patron de diseño usado para transferir datos entre diferentes componentes o capas de una Aplicacion

### Agregar Servicio de Automapper en program.cs

```csharp
builder.Services.ConfigureCors();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());       
```

Pagina 26 Resolver Null Con AutoMapper

## Controladores

- Ruta = WebApi -> Controllers -> **Crear Controladores Necesarios**

```csharp
namespace WebApi.Controllers;
public class CountryController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var countries = await _unitOfWork.Countries.GetAllAsync();
        return _mapper.Map<List<CountryDto>>(countries);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDto>> Get(int id)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }
        return _mapper.Map<CountryDto>(country);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(CountryDto countryDto)
    {
        var country = _mapper.Map<Country>(CountryDto);
        _unitOfWork.Countries.Add(country);
        await _unitOfWork.SaveAsync();
        if (country == null)
        {
            return BadRequest();
        }
        countryDto.Id = country.Id;
        return CreatedAtAction(nameof(Post), new { id = countryDto.Id }, CountryDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto countryDto)
    {
        if (countryDto == null)
            return BadRequest();

        if (countryDto.Id == 0)
            countryDto.Id = id;

        if (countryDto.Id != id)
            return NotFound();
        var countries = _mapper.Map<Country>(countryDto);
        _unitOfWork.Countries.Update(countries);
        await _unitOfWork.SaveAsync();
        return countryDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (country == null)
            return NotFound();

        _unitOfWork.Countries.Remove(country);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}           
```


