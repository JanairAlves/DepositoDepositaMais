using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateIncomingOrder
{
    public class UpdateIncomingOrderCommandHandler : IRequestHandler<UpdateIncomingOrderCommand>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateIncomingOrderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateIncomingOrderCommand request, CancellationToken cancellationToken)
        {
            var incomingOrder = _dbContext.IncomingOrders.SingleOrDefault(io => io.Id == request.Id);

            incomingOrder.Update(
                request.Quantity,
                request.Value,
                request.Description,
                request.ExpectedDeliveryIn
                );

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
