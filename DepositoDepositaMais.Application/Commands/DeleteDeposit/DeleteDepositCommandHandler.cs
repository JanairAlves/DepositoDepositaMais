using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteDeposit
{
    public class DeleteDepositCommandHandler : IRequestHandler<DeleteDepositCommand, Unit>
    {
        private readonly IDepositRepository _depositRepository;
        public DeleteDepositCommandHandler(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        public async Task<Unit> Handle(DeleteDepositCommand request, CancellationToken cancellationToken)
        {
            var deposit = await _depositRepository.GetDepositByIdAsync(request.Id);
            
            deposit.Inactivate();

            await _depositRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
