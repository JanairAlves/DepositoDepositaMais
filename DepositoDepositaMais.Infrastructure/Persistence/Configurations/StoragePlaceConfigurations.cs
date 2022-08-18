using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class StoragePlaceConfigurations : IEntityTypeConfiguration<StoragePlace>
    {
        public void Configure(EntityTypeBuilder<StoragePlace> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .HasMany(sp => sp.Product)
                .WithOne()
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
