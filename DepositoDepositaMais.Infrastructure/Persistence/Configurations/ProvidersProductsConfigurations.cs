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
    public class ProvidersProductsConfigurations : IEntityTypeConfiguration<ProvidersProducts>
    {
        public void Configure(EntityTypeBuilder<ProvidersProducts> builder)
        {
            builder
                .HasKey(pp => pp.Id);

            builder
                .HasOne(pp => pp.Products)
                .WithMany()
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pp => pp.Providers)
                .WithMany()
                .HasForeignKey(p => p.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
