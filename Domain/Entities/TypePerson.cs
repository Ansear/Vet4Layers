using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TypePerson : BaseEntity
{
    public string NameTypePerson { get; set; }
    public ICollection<Person> People { get; set; }
}