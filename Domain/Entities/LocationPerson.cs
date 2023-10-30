using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LocationPerson : BaseEntity
{
    public string TypeRoad { get; set; }
    public int NumberPrincipal { get; set; }
    public string LetterPrincipal { get; set; }
    public string Bis { get; set; }
    public string SecondaryLetter { get; set; }
    public string CardinalPrimary { get; set; }
    public int SecondNumber { get; set; }
    public string TertaryLetter { get; set; }
    public int TertaryNumber { get; set; }
    public string CardinalSecondary { get; set; }
    public string Complement { get; set; }
    public string IdPerson { get; set; }
    public int IdCiudad { get; set; }
    public City Cities { get; set; }
}