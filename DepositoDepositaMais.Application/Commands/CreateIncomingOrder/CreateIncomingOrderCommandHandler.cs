using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateIncomingOrder
{
    public class CreateIncomingOrderCommandHandler : IRequestHandler<CreateIncomingOrderCommand, int>
    {
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        public CreateIncomingOrderCommandHandler(IIncomingOrderRepository incomingOrderRepository)
        {
            _incomingOrderRepository = incomingOrderRepository;
        }

        public async Task<int> Handle(CreateIncomingOrderCommand request, CancellationToken cancellationToken)
        {
            var incomingOrder = new IncomingOrder(
                request.DepositId,
                request.RepresentativeId,
                request.Quantity,
                request.Value,
                request.Description,
                request.Status,
                request.ExpectedDeliveryIn
                );

            await _incomingOrderRepository.CreateIncomingOrder(incomingOrder);

            return incomingOrder.Id;
        }
    }
}
