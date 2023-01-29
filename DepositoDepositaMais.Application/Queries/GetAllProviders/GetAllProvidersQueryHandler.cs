using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllProviders
{
    public class GetAllProvidersQueryHandler : IRequestHandler<GetAllProvidersQuery, List<ProviderViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllProvidersQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProviderViewModel>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
        {
            var provider = _dbContext.Providers;

            var providerViewModel = await provider
                .Select(p => new ProviderViewModel(
                    p.ProviderName,
                    p.CNPJ,
                    p.Site,
                    p.EmailAddress,
                    p.PhoneNumber)
                ).ToListAsync();

            return providerViewModel;
        }
    }
}
