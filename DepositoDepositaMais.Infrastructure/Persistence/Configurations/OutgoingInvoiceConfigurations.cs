using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class OutgoingInvoiceConfigurations : IEntityTypeConfiguration<OutgoingInvoice>
    {
        public void Configure(EntityTypeBuilder<OutgoingInvoice> builder)
        {
            builder
                .HasKey(oi => oi.Id);
        }
    }
}
