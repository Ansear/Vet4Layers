using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Person : BaseEntity
{
    public string PersonName { get; set; }
    public DateOnly DateRegisterPerson { get; set; }
    public int IdRolPerson { get; set; }
    public RolPerson RolPeople { get; set; }
    public int IdTypeDocument { get; set; }
    public TypeDocument TypeDocuments { get; set; }
    public int IdTypePerson { get; set; }
    public TypePerson TypePeople { get; set; }
    public ICollection<ContactPerson> ContactPeople { get; set; }
    public ICollection<MovementInventory> MovementInventories { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
    public LocationPerson LocationPeople { get; set; }
}