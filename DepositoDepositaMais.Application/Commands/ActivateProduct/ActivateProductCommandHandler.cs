using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateProduct
{
    public class ActivateProductCommandHandler : IRequestHandler<ActivateProductCommand, Unit>
    {
        private readonly IDepositRepository _depositRepository;
        public ActivateProductCommandHandler(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        public async Task<Unit> Handle(ActivateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _depositRepository.GetDepositByIdAsync(request.Id);

            product.Activate();

            await _depositRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
