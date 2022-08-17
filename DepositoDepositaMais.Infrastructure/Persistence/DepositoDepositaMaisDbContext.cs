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
        public DbSet<IncomingOrderProducts> IncomingOrderProducts { get; set; }
        public DbSet<OutgoingInvoice> OutgoingInvoices { get; set; }
        public DbSet<OutgoingOrder> OutgoingOrders { get; set; }
        public DbSet<OutgoingOrderProducts> OutgoingOrderProducts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProvidersProducts> ProvidersProducts { get; set; }
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
                .HasForeignKey(d => d.StoragePlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deposit>()
                .HasMany(d => d.Providers)
                .WithOne()
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingInvoice>()
                .HasKey(ii => ii.Id);

            modelBuilder.Entity<IncomingInvoice>()
                .HasMany(ii => ii.IncomingOrders)
                .WithOne()
                .HasForeignKey(ii => ii.IncomingOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingOrder>()
                .HasKey(io => io.Id);

            modelBuilder.Entity<IncomingOrder>()
                .HasOne(io => io.Deposit)
                .WithMany(d => d.IncomingOrders)
                .HasForeignKey(io => io.DepositId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingOrder>()
                .HasOne(io => io.Representative)
                .WithMany(r => r.IncomingOrders)
                .HasForeignKey(io => io.RepresentativeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingOrderProducts>()
                .HasKey(iop => iop.Id);

            modelBuilder.Entity<IncomingOrderProducts>()
                .HasOne(iop => iop.Products)
                .WithMany()
                .HasForeignKey(iop => iop.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<IncomingOrderProducts>()
                .HasOne(iop => iop.IncomingOrders)
                .WithMany()
                .HasForeignKey(io => io.IncomingOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingInvoice>()
                .HasKey(oi => oi.Id);

            modelBuilder.Entity<OutgoingInvoice>()
                .HasMany(oi => oi.OutgoingOrders)
                .WithOne()
                .HasForeignKey(oi => oi.OutgoingOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingOrder>()
                .HasKey(oo => oo.Id);

            modelBuilder.Entity<OutgoingOrder>()
                .HasOne(oo => oo.Deposit)
                .WithMany(d => d.OutgoingOrders)
                .HasForeignKey(oo => oo.DepositId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingOrder>()
                .HasOne(oo => oo.Representative)
                .WithMany(r => r.OutgoingOrders)
                .HasForeignKey(oo => oo.RepresentativeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingOrderProducts>()
                .HasKey(iop => iop.Id);

            modelBuilder.Entity<OutgoingOrderProducts>()
                .HasOne(oop => oop.Products)
                .WithMany()
                .HasForeignKey(oop => oop.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OutgoingOrderProducts>()
                .HasMany(oop => oop.OutgoingOrders)
                .WithOne()
                .HasForeignKey(oo => oo.OutgoingOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Provider>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProvidersProducts>()
                .HasKey(pp => pp.Id);

            modelBuilder.Entity<ProvidersProducts>()
                .HasOne(pp => pp.Products)
                .WithMany()
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProvidersProducts>()
                .HasOne(pp => pp.Providers )
                .WithMany()
                .HasForeignKey(p => p.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Provider>()
                .HasMany(p => p.Representative)
                .WithOne()
                .HasForeignKey(p => p.RepresentativeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Representative>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<StoragePlace>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<StoragePlace>()
                .HasMany(sp => sp.Product)
                .WithOne()
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);           

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(u => u.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Deposit)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => us.Id);
        }
    }
}
