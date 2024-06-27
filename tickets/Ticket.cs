using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Ticket
    {
        public Guid ID { get; set; }
        public DateTime DateCreated { get; set; }

        public Ticket()
        {
            ID = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
        }
    }
}
