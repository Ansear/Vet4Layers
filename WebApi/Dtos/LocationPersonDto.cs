using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos;
public class LocationPersonDto
{
    public string TypeRoad { get; set; }
    public int MainNumber { get; set; }
    public string MainLetter { get; set; }
    public string Bis { get; set; }
    public string SecondaryLetter { get; set; }
    public string CardinalPrimary { get; set; }
    public int SecondNumber { get; set; }
    public string TertaryLetter { get; set; }
    public int TertaryNumber { get; set; }
    public string CardinalSecondary { get; set; }
    public string Complement { get; set; }
    public string ZipCode { get; set; }
    public int IdClient { get; set; }
    public int IdCiudad { get; set; }
}