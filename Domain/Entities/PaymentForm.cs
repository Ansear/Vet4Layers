using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PaymentForm : BaseEntity
{
    public string PaymentFormName { get; set; }
    public ICollection<MovementInventory> MovementInventories { get; set; }
}