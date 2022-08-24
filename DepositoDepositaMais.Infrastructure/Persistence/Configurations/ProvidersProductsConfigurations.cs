using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class ProvidersProductsConfigurations : IEntityTypeConfiguration<ProvidersProducts>
    {
        public void Configure(EntityTypeBuilder<ProvidersProducts> builder)
        {
            builder
                .HasKey(pp => pp.Id);

            builder
                .HasOne(pp => pp.Product)
                .WithMany(p => p.ProvidersProducts)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pp => pp.Provider)
                .WithMany(p => p.ProvidersProducts)
                .HasForeignKey(pp => pp.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
