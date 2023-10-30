using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TypeMovementInventory : BaseEntity
{
    public string NameTypeMovementInventory { get; set; }
    public ICollection<MovementInventory> MovementInventories { get; set; }
}