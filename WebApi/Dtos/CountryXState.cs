using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class CountryXState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DepartamentDto> Departaments { get; set; }
    }
}