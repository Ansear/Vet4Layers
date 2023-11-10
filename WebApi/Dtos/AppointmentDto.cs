using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos;
    public class AppointmentDto
    {
        public int IdDepartament { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int IdClient { get; set; }
        public int IdPet { get; set; }
        public int IdService { get; set; }
    }