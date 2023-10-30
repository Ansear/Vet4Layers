using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MovementInventory : BaseEntity
{
    public DateOnly DateMovementInventory { get; set; }
    public DateOnly DateExpiration { get; set; }
    public int IdPersonResponsible { get; set; }
    public int IdPersonRecipient { get; set; }
    public Person People { get; set; }
    public int IdTypeMovementInventory { get; set; }
    public TypeMovementInventory TypeMovementInventories { get; set; }
    public int IdPaymentForm { get; set; }
    public PaymentForm PaymentForms { get; set; }
    public ICollection<DetailMovementInventory> DetailMovementInventories { get; set; }
}