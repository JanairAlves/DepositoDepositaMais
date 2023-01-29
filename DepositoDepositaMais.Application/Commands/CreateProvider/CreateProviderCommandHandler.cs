using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateProvider
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateProviderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = new Provider(
                request.ProviderName,
                request.Description,
                request.CNPJ,
                request.Site,
                request.EmailAddress,
                request.PhoneNumber,
                request.ProviderType
                );

            await _dbContext.Providers.AddAsync(provider);
            await _dbContext.SaveChangesAsync();

            return provider.Id;
        }
    }
}
