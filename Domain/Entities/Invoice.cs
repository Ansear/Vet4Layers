using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Invoice : BaseEntity
{
    public int InvoiceCurrent { get; set; }
    public int InvoiceInitial { get; set; }
    public int InvoiceFinish { get; set; }
    public string NumberResolution { get; set; }
    public int IdPeople { get; set; }
    public Person People { get; set; }
    public int IdDetailMovementInventory { get; set; }
    public DetailMovementInventory DetailMovementInventories { get; set; }
    
}