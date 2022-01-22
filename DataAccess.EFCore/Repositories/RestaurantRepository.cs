using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Restaurant> GetTopRestaurants(int count)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return _context.Restaurants.OrderByDescending(d => d.Rating).Take(count).ToList();
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}