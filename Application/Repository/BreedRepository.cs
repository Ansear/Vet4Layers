using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;
public class BreedRepository : GenericRepository<Breed>, IBreed
{
    private readonly Vet4Context _context;

    public BreedRepository(Vet4Context context) : base(context)
    {
        _context = context;
    }
}