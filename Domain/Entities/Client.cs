using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Client : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    public LocationPerson LocationPerson { get; set; }
    public ICollection<CustomerPhone> CustomerPhones { get; set; }
    public ICollection<Pet> Pets { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public User User { get; set; }
}