using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Product : BaseEntity
{
    public string ProductName { get; set; }
    public int IdBrand { get; set; }
    public Brand Brands { get; set; }
    public ICollection<Inventory> Inventories {get;set;}
}