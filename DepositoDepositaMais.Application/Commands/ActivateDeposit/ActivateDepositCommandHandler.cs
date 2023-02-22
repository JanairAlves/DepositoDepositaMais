using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateDeposit
{
    public class ActivateDepositCommandHandler : IRequestHandler<ActivateDepositCommand, Unit>
    {
        private readonly IDepositRepository _depositRepository;
        public ActivateDepositCommandHandler(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        public async Task<Unit> Handle(ActivateDepositCommand request, CancellationToken cancellationToken)
        {
            var deposit = await _depositRepository.GetDepositByIdAsync(request.Id);
            
            deposit.Activate();

            await _depositRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
