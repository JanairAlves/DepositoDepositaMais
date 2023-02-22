using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateOutgoingOrder
{
    public class ActivateOutgoingOrderCommandHandler : IRequestHandler<ActivateOutgoingOrderCommand>
    {
        private readonly IOutgoingOrderRepository _outgoingOrderRepository;
        public ActivateOutgoingOrderCommandHandler(IOutgoingOrderRepository outgoingOrderRepository)
        {
            _outgoingOrderRepository = outgoingOrderRepository;
        }

        public async Task<Unit> Handle(ActivateOutgoingOrderCommand request, CancellationToken cancellationToken)
        {
            var outgoingOrder = await _outgoingOrderRepository.GetOutgoingOrderByIdAsync(request.Id);

            outgoingOrder.Activate();

            await _outgoingOrderRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
