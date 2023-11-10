using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos;
public class PetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specie { get; set; }
    public int IdBreed { get; set; }
    public int IdClient { get; set; }
    public DateOnly DateOfBirth { get; set; }
}