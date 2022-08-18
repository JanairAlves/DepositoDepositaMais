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
    public class ProviderConfigurations : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(p => p.Representative)
                .WithOne()
                .HasForeignKey(p => p.RepresentativeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
