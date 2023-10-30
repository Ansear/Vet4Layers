using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Presentation : BaseEntity
{
    public string NamePresentation { get; set; }
    public ICollection<Inventory> Inventories { get; set; }
}