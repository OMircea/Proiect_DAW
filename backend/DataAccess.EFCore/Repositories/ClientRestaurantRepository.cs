using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    public class ClientRestaurantRepository : GenericRepository<ClientRestaurant>, IClientRestaurantRepository
    {
        public ClientRestaurantRepository(ApplicationContext context) : base(context)
        {
        }
    }
}