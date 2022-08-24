using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class ProviderConfigurations : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Deposit)
                .WithMany(d => d.Providers)
                .HasForeignKey(p => p.DepositId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
