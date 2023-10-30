using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class Brand : BaseEntity
    {
        public string BranName { get; set; }
        public ICollection<Product> Products {get; set; }
    }