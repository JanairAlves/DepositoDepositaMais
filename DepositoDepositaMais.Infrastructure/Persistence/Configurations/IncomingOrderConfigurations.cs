using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class IncomingOrderConfigurations : IEntityTypeConfiguration<IncomingOrder>
    {
        public void Configure(EntityTypeBuilder<IncomingOrder> builder)
        {
            builder
                .HasKey(io => io.Id);

            builder
                .HasOne(io => io.Deposit)
                .WithMany(d => d.IncomingOrders)
                .HasForeignKey(io => io.DepositId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(io => io.Representative)
                .WithMany(r => r.IncomingOrders)
                .HasForeignKey(io => io.RepresentativeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
