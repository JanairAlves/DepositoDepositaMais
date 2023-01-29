using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteOutgoingOrder
{
    public class DeleteOutgoingOrderCommandHandler : IRequestHandler<DeleteOutgoingOrderCommand>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public DeleteOutgoingOrderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteOutgoingOrderCommand request, CancellationToken cancellationToken)
        {
            var outgoingOrder = _dbContext.OutgoingOrders.SingleOrDefault(oo => oo.Id == request.Id);

            outgoingOrder.Inactivate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
