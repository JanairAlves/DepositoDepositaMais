using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateProvider
{
    public class ActivateProviderCommandHandler : IRequestHandler<ActivateProviderCommand, Unit>
    {
        private readonly IProviderRepository _providerRepository;
        public ActivateProviderCommandHandler(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<Unit> Handle(ActivateProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = await _providerRepository.GetProviderByIdAsync(request.Id);

            provider.Activate();

            await _providerRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
