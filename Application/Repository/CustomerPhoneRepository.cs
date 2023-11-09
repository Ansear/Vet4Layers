using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;
public class CustomerPhoneRepository : GenericRepository<CustomerPhone>, ICustomerPhone
{
    private readonly Vet4Context _context;

    public CustomerPhoneRepository(Vet4Context context) : base(context)
    {
        _context = context;
    }
}