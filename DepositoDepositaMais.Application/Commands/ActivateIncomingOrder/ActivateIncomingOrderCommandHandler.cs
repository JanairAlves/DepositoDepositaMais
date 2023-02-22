using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateIncomingOrder
{
    public class ActivateIncomingOrderCommandHandler : IRequestHandler<ActivateIncomingOrderCommand, Unit>
    {
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        public ActivateIncomingOrderCommandHandler(IIncomingOrderRepository incomingOrderRepository)
        {
            _incomingOrderRepository = incomingOrderRepository;
        }

        public async Task<Unit> Handle(ActivateIncomingOrderCommand request, CancellationToken cancellationToken)
        {
            var incomingOrder = await _incomingOrderRepository.GetIncomingOrderByIdAsync(request.Id);

            incomingOrder.Activate();

            await _incomingOrderRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
