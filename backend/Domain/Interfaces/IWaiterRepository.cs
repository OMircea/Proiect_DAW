using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IWaiterRepository : IGenericRepository<Waiter>
    {
        IEnumerable<Waiter> GetRestaurantWaiters();
        IEnumerable<Waiter> getWaiterInfos();
    }
}