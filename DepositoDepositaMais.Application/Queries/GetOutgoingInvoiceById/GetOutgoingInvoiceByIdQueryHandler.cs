using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetOutgoingInvoiceById
{
    public class GetOutgoingInvoiceByIdQueryHandler : IRequestHandler<GetOutgoingInvoiceByIdQuery, OutgoingInvoiceDetailsViewModel>
    {
        private readonly IOutgoingInvoiceRepository _outgoingInvoiceRepository;
        public GetOutgoingInvoiceByIdQueryHandler(IOutgoingInvoiceRepository outgoingInvoiceRepository)
        {
            _outgoingInvoiceRepository = outgoingInvoiceRepository;
        }

        public async Task<OutgoingInvoiceDetailsViewModel> Handle(GetOutgoingInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = await _outgoingInvoiceRepository.GetOutgoingInvoiceByIdAsync(request.Id);

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
