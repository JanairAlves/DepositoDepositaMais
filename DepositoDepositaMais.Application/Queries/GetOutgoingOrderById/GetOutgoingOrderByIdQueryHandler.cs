using DepositoDepositaMais.Application.Queries.GetIncomingOrderById;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetOutgoingOrderById
{
    public class GetOutgoingOrderByIdQueryHandler : IRequestHandler<GetOutgoingOrderByIdQuery, OutgoingOrderDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetOutgoingOrderByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OutgoingOrderDetailsViewModel> Handle(GetOutgoingOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var outgoingOrder = await _dbContext.OutgoingOrders
                .Include(oo => oo.Deposit)
                .Include(oo => oo.Representative)
                .SingleOrDefaultAsync(oo => oo.Id == request.Id);

            var outgoingOrderDetailsViewModel = new OutgoingOrderDetailsViewModel(
                outgoingOrder.Id,
                outgoingOrder.DepositId,
                outgoingOrder.StorageLocationId,
                outgoingOrder.ProductId,
                outgoingOrder.Quantity,
                outgoingOrder.Value,
                outgoingOrder.Description,
                outgoingOrder.Status,
                outgoingOrder.CreatedAt,
                outgoingOrder.SendIn,
                outgoingOrder.Deposit.DepositName,
                outgoingOrder.Deposit.CNPJ,
                outgoingOrder.Representative.RepresentativeName,
                outgoingOrder.Representative.CPF,
                outgoingOrder.Representative.PhoneNumber,
                outgoingOrder.Representative.Email
                );

            return outgoingOrderDetailsViewModel;
        }
    }
}
