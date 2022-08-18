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
    public class DepositConfigurations : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .HasMany(d => d.StoragePlaces)
                .WithOne()
                .HasForeignKey(d => d.StoragePlaceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(d => d.Providers)
                .WithOne()
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
