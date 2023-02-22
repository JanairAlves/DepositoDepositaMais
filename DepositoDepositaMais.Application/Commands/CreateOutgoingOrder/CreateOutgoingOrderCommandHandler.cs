using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateOutgoingOrder
{
    public class CreateOutgoingOrderCommandHandler : IRequestHandler<CreateOutgoingOrderCommand, int>
    {
        private readonly IOutgoingOrderRepository _OutgoingOrderRepository;
        public CreateOutgoingOrderCommandHandler(IOutgoingOrderRepository OutgoingOrderRepository)
        {
            _OutgoingOrderRepository = OutgoingOrderRepository;
        }
        public async Task<int> Handle(CreateOutgoingOrderCommand request, CancellationToken cancellationToken)
        {
            var outgoingOrder = new OutgoingOrder(
                request.DepositId,
                request.StorageLocationId,
                request.ProductId,
                request.Quantity,
                request.Value,
                request.Description,
                request.SendIn
                );

            await _OutgoingOrderRepository.CreateOutgoingOrder(outgoingOrder);

            return outgoingOrder.Id;
        }
    }
}
