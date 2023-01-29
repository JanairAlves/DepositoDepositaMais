using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateIncomingOrder
{
    public class ActivateIncomingOrderCommandHandler : IRequestHandler<ActivateIncomingOrderCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateIncomingOrderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateIncomingOrderCommand request, CancellationToken cancellationToken)
        {
            var incomingOrder = _dbContext.IncomingOrders.SingleOrDefault(io => io.Id == request.Id);

            incomingOrder.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
