using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    public class WaiterRepository : GenericRepository<Waiter>, IWaiterRepository
    {
        public WaiterRepository(ApplicationContext context) : base(context)
        { 
        }
        public IEnumerable<Waiter> GetRestaurantWaiters()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return _context.Waiters.Include(x=>x.Restaurant).ToList();
#pragma warning restore CS8604 // Possible null reference argument.
        }
        public IEnumerable<Waiter> getWaiterInfos()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return _context.Waiters.Include(x=>x.Waiter_info).ToList();
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}