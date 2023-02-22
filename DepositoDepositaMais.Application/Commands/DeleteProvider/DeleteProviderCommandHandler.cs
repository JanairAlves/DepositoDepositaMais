using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteProvider
{
    public class DeleteProviderCommandHandler : IRequestHandler<DeleteProviderCommand, Unit>
    {
        private readonly IProviderRepository _providerRepository;
        public DeleteProviderCommandHandler(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<Unit> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = await _providerRepository.GetProviderByIdAsync(request.Id);

            provider.Inactivate();

            await _providerRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
