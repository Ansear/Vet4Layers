using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UnitOfWork;
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Vet4Context _context;
        private readonly IAppointment _appointments;
        private readonly IBreed _breeds;
        private readonly ICity _cities;
        private readonly IClient _clients;
        private readonly ICountry _countries;
        private readonly ICustomerPhone _customerPhones;
        private readonly IDepartament _departaments;
        private readonly ILocationPerson _locationPersons;
        private readonly IPet _pets;
        private readonly IRolRepository _roles;
        private readonly IUserRepositoty _users;
        private readonly IService services;
        public UnitOfWork(Vet4Context context)
        {
            _context = contex
        }

        public IAppointment Appointments
        {
            get
            {
                _appointments ??= new AppointmentRepository(_context);
                return _appointments;
            }
        }
    }