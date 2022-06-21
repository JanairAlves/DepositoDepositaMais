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
        public DbSet<Storage> Storagehouse { get; set; }
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

            modelBuilder.Entity<IncomingInvoice>()
                .HasKey(ii => ii.Id);



            modelBuilder.Entity<IncomingOrder>()
                .HasKey(io => io.Id);

            modelBuilder.Entity<IncomingOrder>()
                .HasOne(io => io.Deposit)
                .WithMany(d => d.IncomingOrder)
                .HasForeignKey(io => io.IdDeposit)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingOrder>()
                .HasOne(io => io.Representative)
                .WithMany(r => r.IncomingOrder)
                .HasForeignKey(io => io.IdRepresentative)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomingOrder>()
                .HasMany(io => io.Products)
                .WithMany(p => p.IncomingOrder)
                .Has


            modelBuilder.Entity<OutgoingInvoice>()
                .HasKey(oi => oi.Id);

            modelBuilder.Entity<OutgoingOrder>()
                .HasKey(oo => oo.Id);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Provider>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Representative>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Skill>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Storage>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => us.Id);
        }
    }
}
