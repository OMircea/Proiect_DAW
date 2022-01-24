﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    public class ClientRepository : GenericRepository<Waiter>, IClientRepository
    {
        public ClientRepository(ApplicationContext context) : base(context)
        {
        }
    }
}