using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {   
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Occupation { get; set; }
        public int Age { get; set; }
        public ICollection<ClientRestaurant>? ClientRestaurants { get; set; }

    }
}
