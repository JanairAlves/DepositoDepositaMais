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
                .HasMany(io => io.IncomingOrderProducts)
                .WithOne(iop => iop.Product)
                .HasForeignKey(io => io.IdProduct)
                .OnDelete(DeleteBehavior.Restrict);
            // Na formação Formação ASP.NET Core,
            // Do modulo Persistência com Entity Framework Core,
            // Aula Configurando as Entidades Para Tabelas - Parte 2,
            // Entre o tempo 6min50seg e 8min10seg.

            /* Na definição do relacionamento entre as entidades, e usado o WithOne sem informar a propriedade de navegação, 
             * pois no contexto não houve a necessidade.
             * Enquanto vou fazendo o curso e fazendo o projeto do projeto do curso, em paralelo vou fazendo um outro projeto pessoal,
             * no contexto desse projeto, entendo que seria interessante passa a própriedade de navegação para recuperação dos dados.
             * Tentei fazer aqui dessa forma `.WithOne(iop => iop.Product)`, mas está me retornando o erro 
             * "CS0029: Cannot implicitly convert type 'DepositoDepositaMais.Core.Entities.Product' to 'DepositoDepositaMais.Core.Entities.IncomingOrder'"
             * e
             * "CS1662: Cannot convert lambda Expression to intended delegate type because some of the return types in the block are not implicitly convertible to the delegate return type"
             */


            modelBuilder.Entity<IncomingOrderProducts>()
                .HasKey(io => io.Id);

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
