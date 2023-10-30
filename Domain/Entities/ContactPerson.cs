using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactPerson
    {
        public int IdPerson { get; set; }
        public Person People { get; set; }
        public int IdTypeContact { get; set; }
        public TypeContact TypeContacts { get; set; }
    }
}