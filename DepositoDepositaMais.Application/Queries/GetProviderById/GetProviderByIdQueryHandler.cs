using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetProviderById
{
    public class GetProviderByIdQueryHandler : IRequestHandler<GetProviderByIdQuery, ProviderDetailsViewModel>
    {
        private readonly IProviderRepository _providerRepository;
        public GetProviderByIdQueryHandler(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<ProviderDetailsViewModel> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
        {
            var provider = await _providerRepository.GetProviderByIdAsync(request.Id);

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
