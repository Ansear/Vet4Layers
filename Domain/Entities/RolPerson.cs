using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class RolPerson : BaseEntity
{
    public string RolPersonName { get; set; }
    public ICollection<Person> People { get; set; }
}