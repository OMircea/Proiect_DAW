using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    public class Waiter_infoRepository : GenericRepository<Waiter_info>, IWaiter_infoRepository
    {
        public Waiter_infoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}