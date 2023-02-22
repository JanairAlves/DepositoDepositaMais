using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteRepresentative
{
    public class DeleteRepresentativeCommandHandler : IRequestHandler<DeleteRepresentativeCommand, Unit>
    {
        private readonly IDepositRepository _depositRepository;
        public DeleteRepresentativeCommandHandler(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        public async Task<Unit> Handle(DeleteRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var representative = await _depositRepository.GetDepositByIdAsync(request.Id);

            representative.Inactivate();

            await _depositRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
