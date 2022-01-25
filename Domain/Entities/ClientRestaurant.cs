using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClientRestaurant
    {
        public int IdClient { get; set; }
        public int IdRestaurant { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        public virtual Client? Client { get; set; }
    }
}
