using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
        IEnumerable<Restaurant> GetTopRestaurants(int count);
    }
}