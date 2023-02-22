using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateRepresentative
{
    public class ActivateRepresentativeCommandHandler : IRequestHandler<ActivateRepresentativeCommand, Unit>
    {
        private readonly IRepresentativeRepository _representativeRepository;
        public ActivateRepresentativeCommandHandler(IRepresentativeRepository representativeRepository)
        {
            _representativeRepository = representativeRepository;
        }

        public async Task<Unit> Handle(ActivateRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var representative = await _representativeRepository.GetRepresentativeByIdAsync(request.Id);

            representative.Activate();

            await _representativeRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
