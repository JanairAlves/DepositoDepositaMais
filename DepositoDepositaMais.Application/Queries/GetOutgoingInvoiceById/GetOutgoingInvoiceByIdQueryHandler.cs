using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetOutgoingInvoiceById
{
    public class GetOutgoingInvoiceByIdQueryHandler : IRequestHandler<GetOutgoingInvoiceByIdQuery, OutgoingInvoiceDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetOutgoingInvoiceByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OutgoingInvoiceDetailsViewModel> Handle(GetOutgoingInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = await _dbContext.OutgoingInvoices.SingleOrDefaultAsync(oi => oi.Id == request.Id);

            var outgoingInvoiceDetailsViewModel = new OutgoingInvoiceDetailsViewModel(
                outgoingInvoice.Id,
                outgoingInvoice.DepositId,
                outgoingInvoice.StorageLocationId,
                outgoingInvoice.ProductId,
                outgoingInvoice.Quantity,
                outgoingInvoice.Value,
                outgoingInvoice.Description,
                outgoingInvoice.Status,
                outgoingInvoice.CreatedAt,
                outgoingInvoice.SubmittedIn
                );

            return outgoingInvoiceDetailsViewModel;
        }
    }
}
