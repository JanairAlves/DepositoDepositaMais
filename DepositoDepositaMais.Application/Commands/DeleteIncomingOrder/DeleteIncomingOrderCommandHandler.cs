using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteIncomingOrder
{
    public class DeleteIncomingOrderCommandHandler : IRequestHandler<DeleteIncomingOrderCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public DeleteIncomingOrderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteIncomingOrderCommand request, CancellationToken cancellationToken)
        {
            var incomingOrder = _dbContext.IncomingOrders.SingleOrDefault(io => io.Id == request.Id);

            incomingOrder.Inactivate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
