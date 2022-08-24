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
                .HasOne(iop => iop.IncomingOrder)
                .WithMany(io => io.IncomingOrderProducts)
                .HasForeignKey(iop => iop.IncomingOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(iop => iop.Product)
                .WithMany(p => p.IncomingOrderProducts)
                .HasForeignKey(iop => iop.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
