using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Waiter_info
    {   
        public int Id { get; set; }
        public string? Street { get; set; }
        public int? Number { get; set; }
        public string? City { get; set; }
        public int WaiterId { get; set; }
        public Waiter? Waiter { get; set; }
    }
}
