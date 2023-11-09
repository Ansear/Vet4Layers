using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

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

    public IAppointment Appointments
    {
        get
        {
            _appointments ??= new AppointmentRepository(_context);
            return _appointments;
        }
    }
    public IBreed Breeds
    {
        get
        {
            _breeds ??= new BreedRepository(_context);
            return _breeds;
        }
    }

    public ICity Cities
    {
        get
        {
            _cities ??= new CityRepository(_context);
            return _cities;
        }
    }

    public IClient Clients
    {
        get
        {
            _clients ??= new ClientRepository(_context);
            return _clients;
        }
    }

    public ICountry Countries
    {
        get
        {
            _countries ??= new CountryRepository(_context);
            return _countries;
        }
    }

    public ICustomerPhone CustomerPhones
    {
        get
        {
            _customerPhones ??= new CustomerPhoneRepository(_context);
            return _customerPhones;
        }
    }

    public IDepartament Departaments
    {
        get
        {
            _departaments ??= new DepartamentRepository(_context);
            return _departaments;
        }
    }

    public ILocationPerson LocationPeople
    {
        get
        {
            _locationPersons ??= new LocationPersonRepository(_context);
            return _locationPersons;
        }
    }

    public IPet Pets
    {
        get
        {
            _pets ??= new PetRepository(_context);
            return _pets;
        }
    }

    public IRolRepository Roles
    {
        get
        {
            _roles ??= new RolRepository(_context);
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }

    public IService Services
    {
        get
        {
            _services ??= new ServiceRepository(_context);
            return _services;
        }
    }
    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}