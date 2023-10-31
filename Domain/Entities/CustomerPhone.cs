using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CustomerPhone : BaseEntity
{
    [Required]
    public int IdClient { get; set; }
    public Client Clients { get; set; }
    [Required]
    public string Number { get; set; }
}