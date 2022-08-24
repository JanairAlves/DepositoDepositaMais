using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class OutgoingOrderProductsConfigurations : IEntityTypeConfiguration<OutgoingOrderProducts>
    {
        public void Configure(EntityTypeBuilder<OutgoingOrderProducts> builder)
        {
            builder
                .HasKey(iop => iop.Id);

            builder
                .HasOne(oop => oop.Product)
                .WithMany(p => p.OutgoingOrderProducts)
                .HasForeignKey(oop => oop.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(oop => oop.OutgoingOrder)
                .WithMany(oo => oo.OutgoingOrderProducts)
                .HasForeignKey(oop => oop.OutgoingOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
