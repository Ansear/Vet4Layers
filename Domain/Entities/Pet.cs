using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Pet : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Species { get; set; }
    [Required]
    public int IdBreed { get; set; }
    public Breed Breeds { get; set}
    [Required]
    public DateOnly DateOfBirth { get; set; }
    [Required]
    public int IdClient { get; set; }
    public Client Clients { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}