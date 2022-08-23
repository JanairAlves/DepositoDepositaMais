﻿using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace DepositoDepositaMais.Infrastructure.Persistence
{
    public class DepositoDepositaMaisDbContext : DbContext
    {
        public DepositoDepositaMaisDbContext(DbContextOptions<DepositoDepositaMaisDbContext> options) : base(options)
        {
            //Debugger.Launch();
            //Debugger.Break();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<StoragePlace> StoragePlace { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<IncomingInvoice> IncomingInvoices { get; set; }
        public DbSet<IncomingOrder> IncomingOrders { get; set; }
        public DbSet<IncomingOrderProducts> IncomingOrderProducts { get; set; }
        public DbSet<OutgoingInvoice> OutgoingInvoices { get; set; }
        public DbSet<OutgoingOrder> OutgoingOrders { get; set; }
        public DbSet<OutgoingOrderProducts> OutgoingOrderProducts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProvidersProducts> ProvidersProducts { get; set; }
        public DbSet<Representative> Representatives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IncomingOrder>().HasKey(io => io.Id);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
