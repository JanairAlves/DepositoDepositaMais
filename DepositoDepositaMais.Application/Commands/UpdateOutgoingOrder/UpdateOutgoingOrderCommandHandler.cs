using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateOutgoingOrder
{
    public class UpdateOutgoingOrderCommandHandler : IRequestHandler<UpdateOutgoingOrderCommand, Unit>
    {
        private readonly IOutgoingOrderRepository _outgoingOrderRepository;
        public UpdateOutgoingOrderCommandHandler(IOutgoingOrderRepository outgoingOrderRepository)
        {
            _outgoingOrderRepository = outgoingOrderRepository;
        }

        public async Task<Unit> Handle(UpdateOutgoingOrderCommand request, CancellationToken cancellationToken)
        {
            var outgoingOrder = await _outgoingOrderRepository.GetOutgoingOrderByIdAsync(request.Id);

            outgoingOrder.Update(
                request.StorageLocationId,
                request.ProductId,
                request.Quantity,
                request.Value,
                request.Description,
                request.SendIn
                );

            await _outgoingOrderRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
