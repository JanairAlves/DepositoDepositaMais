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
    public class OutgoingOrderConfigurations : IEntityTypeConfiguration<OutgoingOrder>
    {
        public void Configure(EntityTypeBuilder<OutgoingOrder> builder)
        {
            builder
                .HasKey(oo => oo.Id);

            builder
                .HasOne(oo => oo.Deposit)
                .WithMany(d => d.OutgoingOrders)
                .HasForeignKey(oo => oo.DepositId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(oo => oo.Representative)
                .WithMany(r => r.OutgoingOrders)
                .HasForeignKey(oo => oo.RepresentativeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
