using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos;
public class CustomerPhoneDto
{
    public int Id { get; set; }
    public int IdClient { get; set; }
    public string Number { get; set; }
}