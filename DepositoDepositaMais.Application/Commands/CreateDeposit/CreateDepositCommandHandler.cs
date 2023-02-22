using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateDeposit
{
    public class CreateDepositCommandHandler : IRequestHandler<CreateDepositCommand, int>
    {
        private readonly IDepositRepository _depositRepository;
        public CreateDepositCommandHandler(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        public async Task<int> Handle(CreateDepositCommand request, CancellationToken cancellationToken)
        {
            var deposit = new Deposit(
                request.DepositName,
                request.Description,
                request.CNPJ
                );

            await _depositRepository.CreateDepositAsync(deposit);

            return deposit.Id;
        }
    }
}
