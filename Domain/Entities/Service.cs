using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class Service : BaseEntity
    {
        [Required]
        public string Name {get;set;}
        [Required]
        public double Precio {get;set;}
        public ICollection<Appointment> Appointments {get;set;} 
    }