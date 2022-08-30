using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class StorageLocationConfigurations : IEntityTypeConfiguration<StorageLocation>
    {
        public void Configure(EntityTypeBuilder<StorageLocation> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .HasOne(s => s.Deposit)
                .WithMany(d => d.StorageLocations)
                .HasForeignKey(s => s.DepositId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
