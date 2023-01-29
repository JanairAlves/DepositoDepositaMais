using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetProviderById
{
    public class GetProviderByIdQueryHandler : IRequestHandler<GetProviderByIdQuery, ProviderDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetProviderByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProviderDetailsViewModel> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
        {
            var provider = await _dbContext.Providers.SingleOrDefaultAsync(p => p.Id == request.Id);

            var providerDetailsViewModel = new ProviderDetailsViewModel(
                provider.Id,
                provider.ProviderName,
                provider.Description,
                provider.CNPJ,
                provider.Site,
                provider.EmailAddress,
                provider.PhoneNumber,
                provider.ProviderType,
                provider.Status,
                provider.CreatedAt
                );

            return providerDetailsViewModel;
        }
    }
}
