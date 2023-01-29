using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateIncomingOrder
{
    public class CreateIncomingOrderCommandHandler : IRequestHandler<CreateIncomingOrderCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateIncomingOrderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
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

            await _dbContext.IncomingOrders.AddAsync(incomingOrder);
            await _dbContext.SaveChangesAsync();

            return incomingOrder.Id;
        }
    }
}
