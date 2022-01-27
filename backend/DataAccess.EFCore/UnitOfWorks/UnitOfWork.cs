using DataAccess.EFCore.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Restaurants = new RestaurantRepository(_context);
            Waiters = new WaiterRepository(_context);
            Waiter_infos = new Waiter_infoRepository(_context);
            Clients = new ClientRepository(_context);
            ClientRestaurants = new ClientRestaurantRepository(_context);
            Users = new UserRepository(_context);
        }
        public IRestaurantRepository Restaurants { get; private set; }
        public IWaiterRepository Waiters { get; private set; }
        public IWaiter_infoRepository Waiter_infos { get; private set; }
        public IClientRepository Clients { get; private set; }
        public IClientRestaurantRepository ClientRestaurants { get; private set; }
        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}