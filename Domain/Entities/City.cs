using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class City : BaseEntity
{
    public string Name { get; set; }
    public int IdDepartament { get; set; }
    public Departament Departaments { get; set; }
    public LocationPerson LocationPerson { get; set; }
}