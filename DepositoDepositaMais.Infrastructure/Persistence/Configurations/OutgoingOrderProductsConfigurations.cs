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
    public class OutgoingOrderProductsConfigurations : IEntityTypeConfiguration<OutgoingOrderProducts>
    {
        public void Configure(EntityTypeBuilder<OutgoingOrderProducts> builder)
        {
            builder
                .HasKey(iop => iop.Id);

            builder
                .HasOne(oop => oop.Products)
                .WithMany()
                .HasForeignKey(oop => oop.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(oop => oop.OutgoingOrders)
                .WithOne()
                .HasForeignKey(oo => oo.OutgoingOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
