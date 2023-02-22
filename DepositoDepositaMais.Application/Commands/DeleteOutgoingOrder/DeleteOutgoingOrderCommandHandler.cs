using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteOutgoingOrder
{
    public class DeleteOutgoingOrderCommandHandler : IRequestHandler<DeleteOutgoingOrderCommand>
    {
        private readonly IOutgoingOrderRepository _outgoingOrderRepository;
        public DeleteOutgoingOrderCommandHandler(IOutgoingOrderRepository outgoingOrderRepository)
        {
            _outgoingOrderRepository = outgoingOrderRepository;
        }

        public async Task<Unit> Handle(DeleteOutgoingOrderCommand request, CancellationToken cancellationToken)
        {
            var outgoingOrder = await _outgoingOrderRepository.GetOutgoingOrderByIdAsync(request.Id);

            outgoingOrder.Inactivate();

            await _outgoingOrderRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
