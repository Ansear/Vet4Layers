using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;
public class DepartamentRepository : GenericRepository<Departament>, IDepartament
{
    private readonly Vet4Context _context;

    public DepartamentRepository(Vet4Context context) : base(context)
    {
        _context = context;
    }
}