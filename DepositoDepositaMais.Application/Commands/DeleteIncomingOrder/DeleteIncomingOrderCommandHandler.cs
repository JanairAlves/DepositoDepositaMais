using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteIncomingOrder
{
    public class DeleteIncomingOrderCommandHandler : IRequestHandler<DeleteIncomingOrderCommand, Unit>
    {
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        public DeleteIncomingOrderCommandHandler(IIncomingOrderRepository incomingOrderRepository)
        {
            _incomingOrderRepository = incomingOrderRepository;
        }

        public async Task<Unit> Handle(DeleteIncomingOrderCommand request, CancellationToken cancellationToken)
        {
            var incomingOrder = await _incomingOrderRepository.GetIncomingOrderByIdAsync(request.Id);

            incomingOrder.Inactivate();

            await _incomingOrderRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
