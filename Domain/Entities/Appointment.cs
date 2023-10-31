using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Appointment : BaseEntity
{
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public TimeOnly Time { get; set; }
    [Required]
    public int IdClient {get;set;}
    public Client Clients { get; set; }
    [Required]
    public int IdPet {get;set;}
    public Pet Pets {get;set;}
    [Required]
    public int Service {get;set;}
    public Service Services {get;set;}
}