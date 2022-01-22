using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Waiter
    {
        public int Id { get; set; }
        public string? Last_Name { get; set; }
        public string? First_Name { get; set; }
        public int Rating { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Waiter_info? Waiter_info { get; set; }
    }
}
