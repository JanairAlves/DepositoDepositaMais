using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllProviders
{
    public class GetAllProvidersQueryHandler : IRequestHandler<GetAllProvidersQuery, List<ProviderViewModel>>
    {
        private readonly IProviderRepository _providerRepository;
        public GetAllProvidersQueryHandler(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<List<ProviderViewModel>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
        {
            var providers = await _providerRepository.GetAllProvidersAsync();

            var providersViewModel = providers
                .Select(p => new ProviderViewModel(
                    p.ProviderName,
                    p.CNPJ,
                    p.Site,
                    p.EmailAddress,
                    p.PhoneNumber)
                ).ToList();

            return providersViewModel;
        }
    }
}
