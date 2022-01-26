using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRestaurantRepository Restaurants { get; }
        IWaiterRepository Waiters { get; }
        IWaiter_infoRepository Waiter_infos { get; }
        IClientRepository Clients { get; }
        IClientRestaurantRepository ClientRestaurants { get; }
        IUserRepository Users { get; }

        int Complete();
    }
}