using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Rating { get; set; }

        public List<Waiter>? Waiters { get; set; }
        public ICollection<Client>? Clients { get; set; }
    }
}
