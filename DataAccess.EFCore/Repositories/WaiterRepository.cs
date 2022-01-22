using Domain.Entities;
using Domain.Interfaces;
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
    }
}