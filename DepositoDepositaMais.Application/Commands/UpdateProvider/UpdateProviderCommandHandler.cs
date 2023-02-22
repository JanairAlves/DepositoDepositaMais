using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateProvider
{
    public class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand, Unit>
    {
        private readonly IProviderRepository _providerRepository;
        public UpdateProviderCommandHandler(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<Unit> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = await _providerRepository.GetProviderByIdAsync(request.Id);

            provider.Update(
                request.providerName,
                request.Description,
                request.CNPJ,
                request.Site,
                request.EmailAddress,
                request.PhoneNumber,
                request.ProviderType
                );

            await _providerRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
