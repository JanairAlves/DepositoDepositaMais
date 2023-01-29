using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateOutgoingOrder
{
    public class CreateOutgoingOrderCommandHandler : IRequestHandler<CreateOutgoingOrderCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext  _dbContext;
        public CreateOutgoingOrderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
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

            await _dbContext.OutgoingOrders.AddAsync(outgoingOrder);
            await _dbContext.SaveChangesAsync();

            return outgoingOrder.Id;
        }
    }
}
