using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class IncomingOrderProductsConfigurations : IEntityTypeConfiguration<IncomingOrderProducts>
    {
        public void Configure(EntityTypeBuilder<IncomingOrderProducts> builder)
        {
            builder
                .HasKey(iop => iop.Id);

            builder
                .HasOne(iop => iop.Products)
                .WithMany()
                .HasForeignKey(iop => iop.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(iop => iop.IncomingOrders)
                .WithMany()
                .HasForeignKey(io => io.IncomingOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
