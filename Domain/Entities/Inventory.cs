using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Inventory : BaseEntity
{
    public string InventoryName { get; set; }
    public double PrecioInventory { get; set; }
    public int CurrentStock { get; set; }
    public int MinimumStock { get; set; }
    public int MaximumStock { get; set; }
    public string IdProduct { get; set; }
    public Product Products { get; set; }
    public int IdPresentation { get; set; }
    public Presentation Presentations { get; set; }
    public ICollection<DetailMovementInventory> DetailMovementInventories { get; set; }
}