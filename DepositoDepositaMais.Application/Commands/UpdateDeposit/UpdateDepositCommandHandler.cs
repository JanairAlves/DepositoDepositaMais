using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateDeposit
{
    public class UpdateDepositCommandHandler : IRequestHandler<UpdateDepositCommand, Unit>
    {
        private readonly IDepositRepository _depositRepository;
        public UpdateDepositCommandHandler(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        public async Task<Unit> Handle(UpdateDepositCommand request, CancellationToken cancellationToken)
        {
            var deposit = await _depositRepository.GetDepositByIdAsync(request.Id);

            deposit.Update(request.DepositName, request.Description, request.CNPJ);

            await _depositRepository.SaveChangesAsync();


            return Unit.Value;
        }
    }
}
