using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateOutgoingOrder
{
    public class ActivateOutgoingOrderCommandHandler : IRequestHandler<ActivateOutgoingOrderCommand>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateOutgoingOrderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateOutgoingOrderCommand request, CancellationToken cancellationToken)
        {
            var outgoingOrder = _dbContext.OutgoingOrders.SingleOrDefault(oo => oo.Id == request.Id);

            outgoingOrder.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
