using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class StoragePlaceConfigurations : IEntityTypeConfiguration<StoragePlace>
    {
        public void Configure(EntityTypeBuilder<StoragePlace> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .HasOne(s => s.Deposit)
                .WithMany(d => d.StoragePlaces)
                .HasForeignKey(s => s.DepositId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
