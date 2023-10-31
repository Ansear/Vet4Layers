using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IAppointment Appointments { get; }
    ICity City { get; }
    IClient Clients { get; }
    ILocationPerson LocationPeople { get; }
    ICustomerPhone CustomerPhones { get; }
    IDepartament Departaments { get; }
    IPet Pets { get; }
    ICountry Countries { get; }
    IBreed Breeds { get; }
    IService Services { get; }
    IRolRepository Roles { get; }
    IUserRepository Users { get; }
    Task<int> SaveAsync();
}