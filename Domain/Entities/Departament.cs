using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Departament : BaseEntity
{
    public string Name { get; set; }
    public int IdCountry { get; set; }
    public Country Countries { get; set; }
    public ICollection<City> Cities { get; set; }
}