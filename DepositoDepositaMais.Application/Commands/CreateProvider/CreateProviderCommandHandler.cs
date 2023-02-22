using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateProvider
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, int>
    {
        private readonly IProviderRepository _providerRepository;
        public CreateProviderCommandHandler(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
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

            await _providerRepository.CreateProvider(provider);

            return provider.Id;
        }
    }
}
