using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class DetailMovementInventory : BaseEntity
{
    public int Quantity { get; set; }
    public double Price { get; set; }
    public int IdInventory { get; set; }
    public Inventory Inventories { get; set; }
    public string IdMovementInventory { get; set; }
    public DetailMovementInventory MovementInventories { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
}