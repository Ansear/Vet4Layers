using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace WebApi.Dtos;
public class DepartamentDto
{
    public string Name { get; set; }
    public int IdCountry { get; set; }
    public Country Countries { get; set; }
}