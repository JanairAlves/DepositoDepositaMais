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
    public class IncomingInvoiceConfigurations : IEntityTypeConfiguration<IncomingInvoice>
    {
        public void Configure(EntityTypeBuilder<IncomingInvoice> builder)
        {
            builder
                .HasKey(ii => ii.Id);

            builder
                .HasMany(ii => ii.IncomingOrders)
                .WithOne()
                .HasForeignKey(ii => ii.IncomingOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
