using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateIncomingOrder
{
    public class UpdateIncomingOrderCommandHandler : IRequestHandler<UpdateIncomingOrderCommand>
    {
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        public UpdateIncomingOrderCommandHandler(IIncomingOrderRepository incomingOrderRepository)
        {
            _incomingOrderRepository = incomingOrderRepository;
        }

        public async Task<Unit> Handle(UpdateIncomingOrderCommand request, CancellationToken cancellationToken)
        {
            var incomingOrder = await _incomingOrderRepository.GetIncomingOrderByIdAsync(request.Id);

            incomingOrder.Update(
                request.Quantity,
                request.Value,
                request.Description,
                request.ExpectedDeliveryIn
                );

            await _incomingOrderRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
