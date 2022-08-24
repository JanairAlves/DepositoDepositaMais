using DepositoDepositaMais.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoDepositaMais.Infrastructure.Persistence.Configurations
{
    public class IncomingInvoiceConfigurations : IEntityTypeConfiguration<IncomingInvoice>
    {
        public void Configure(EntityTypeBuilder<IncomingInvoice> builder)
        {
            builder
                .HasKey(ii => ii.Id);
        }
    }
}
