using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetIncomingOrderById
{
    public class GetIncomingOrderByIdQueryHandler : IRequestHandler<GetIncomingOrderByIdQuery, IncomingOrderDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetIncomingOrderByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IncomingOrderDetailsViewModel> Handle(GetIncomingOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var incomingOrder = await _dbContext.IncomingOrders
                .Include(io => io.Deposit)
                .Include(io => io.Representative)
                .SingleOrDefaultAsync(io => io.Id == request.Id);

            var incomingOrderDetailsViewModel = new IncomingOrderDetailsViewModel(
                incomingOrder.Id,
                incomingOrder.DepositId,
                incomingOrder.RepresentativeId,
                incomingOrder.Quantity,
                incomingOrder.Value,
                incomingOrder.Description,
                incomingOrder.Status,
                incomingOrder.CreatedAt,
                incomingOrder.ExpectedDeliveryIn,
                incomingOrder.Deposit.DepositName,
                incomingOrder.Deposit.CNPJ,
                incomingOrder.Representative.RepresentativeName,
                incomingOrder.Representative.CPF,
                incomingOrder.Representative.PhoneNumber,
                incomingOrder.Representative.Email
                );

            return incomingOrderDetailsViewModel;
        }
    }
}
