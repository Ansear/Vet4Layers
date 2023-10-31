using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Breed : BaseEntity
{
    public string BreedName { get; set; }
    public ICollection<Pet> Pets { get; set; }
}