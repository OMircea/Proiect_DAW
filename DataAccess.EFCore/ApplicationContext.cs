using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Restaurant>? Restaurants { get; set; }
        public DbSet<Waiter>? Waiters { get; set; }
        public DbSet<Waiter_info>? Waiter_infos { get; set; }
    }
}