using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TypeContact : BaseEntity
{
    public string TypeContactName { get; set; }
    public ICollection<ContactPerson> ContactPeople { get; set; }
}