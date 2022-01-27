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
        public DbSet<ClientRestaurant>? ClientRestaurants { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientRestaurant>()
                .HasKey(bc => new { bc.IdClient, bc.IdRestaurant });
            modelBuilder.Entity<ClientRestaurant>()
                .HasOne(bc => bc.Client)
                .WithMany(b => b.ClientRestaurants)
                .HasForeignKey(bc => bc.IdClient);
            modelBuilder.Entity<ClientRestaurant>()
                .HasOne(bc => bc.Restaurant)
                .WithMany(c => c.ClientRestaurants)
                .HasForeignKey(bc => bc.IdRestaurant);
        }
    }

}