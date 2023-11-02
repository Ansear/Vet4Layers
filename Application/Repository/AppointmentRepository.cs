using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository;
public class AppointmentRepository : GenericRepository<Appointment>, IAppointment
{
    private readonly Vet4Context _context;

    public AppointmentRepository(Vet4Context context) : base(context)
    {
        _context = context;
    }
}