using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateOutgoingOrder
{
    public class UpdateOutgoingOrderCommandHandler : IRequestHandler<UpdateOutgoingOrderCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateOutgoingOrderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateOutgoingOrderCommand request, CancellationToken cancellationToken)
        {
            var outgoingOrder = _dbContext.OutgoingOrders.SingleOrDefault(oo => oo.Id == request.Id);

            outgoingOrder.Update(
                request.StorageLocationId,
                request.ProductId,
                request.Quantity,
                request.Value,
                request.Description,
                request.SendIn
                );

            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
