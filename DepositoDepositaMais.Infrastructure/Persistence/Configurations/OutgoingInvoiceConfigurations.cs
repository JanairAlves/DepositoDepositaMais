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
    public class OutgoingInvoiceConfigurations : IEntityTypeConfiguration<OutgoingInvoice>
    {
        public void Configure(EntityTypeBuilder<OutgoingInvoice> builder)
        {
            builder
                .HasKey(oi => oi.Id);

            builder
                .HasMany(oi => oi.OutgoingOrders)
                .WithOne()
                .HasForeignKey(oi => oi.OutgoingOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
