using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepositoDepositaMais.Infrastructure.Persistence
{
    public class DepositoDepositaMaisDbContext : DbContext
    {
        public DepositoDepositaMaisDbContext(DbContextOptions<DepositoDepositaMaisDbContext> options) : base(options)
        {
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
        public DbSet<OutgoingInvoice> OutgoingInvoices { get; set; }
        public DbSet<OutgoingOrder> OutgoingOrders { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Representative> Representatives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Deposit>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Deposit>()
                .HasMany(d => d.StoragePlaces)
                .WithOne()
                .HasForeignKey(d => d.IdStoragePlace)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deposit>()
                .HasMany(d => d.Representatives)
                .WithOne()
                .HasForeignKey(d => d.IdRepresentative)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingInvoice>()
                .HasKey(ii => ii.Id);

            modelBuilder.Entity<IncomingInvoice>()
                .HasMany(ii => ii.IncomingOrders)
                .WithOne()
                .HasForeignKey(ii => ii.IdIncomingOrder)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingOrder>()
                .HasKey(io => io.Id);

            modelBuilder.Entity<IncomingOrder>()
                .HasOne(io => io.Deposit)
                .WithMany(d => d.IncomingOrders)
                .HasForeignKey(io => io.IdDeposit)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingOrder>()
                .HasOne(io => io.Representative)
                .WithMany(r => r.IncomingOrders)
                .HasForeignKey(io => io.IdRepresentative)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingOrder>()
                .HasMany(io => io.IncomingOrderProducts)
                .WithOne()
                .HasForeignKey(io => io.IdIncomingOrder)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingOrderProducts>()
                .HasKey(iop => iop.Id);

            modelBuilder.Entity<IncomingOrderProducts>()
                .HasOne(iop => iop.Product)
                .WithMany()
                .HasForeignKey(iop => iop.IdProduct)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingInvoice>()
                .HasKey(oi => oi.Id);

            modelBuilder.Entity<OutgoingInvoice>()
                .HasMany(oi => oi.OutgoingOrders)
                .WithOne()
                .HasForeignKey(oi => oi.IdOutgoingOrder)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingOrder>()
                .HasKey(oo => oo.Id);

            modelBuilder.Entity<OutgoingOrder>()
                .HasOne(oo => oo.Deposit)
                .WithMany(d => d.OutgoingOrders)
                .HasForeignKey(oo => oo.IdDeposit)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingOrder>()
                .HasOne(oo => oo.Representative)
                .WithMany(r => r.OutgoingOrders)
                .HasForeignKey(oo => oo.IdRepresentative)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingOrder>()
                .HasMany(oo => oo.OutgoingOrderProducts)
                .WithOne()
                .HasForeignKey(oo => oo.IdOutgoingOrder)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingOrderProducts>()
                .HasKey(iop => iop.Id);

            modelBuilder.Entity<OutgoingOrderProducts>()
                .HasOne(oop => oop.Product)
                .WithMany()
                .HasForeignKey(oop => oop.IdProduct)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Provider>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Representative>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<StoragePlace>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Skill>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => us.Id);
        }
    }
}
