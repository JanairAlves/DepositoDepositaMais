using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllOutgoingInvoices
{
    public class GetAllOutgoingInvoicesQueryHandler : IRequestHandler<GetAllOutgoingInvoicesQuery, List<OutgoingInvoiceViewModel>>
    {
        private readonly IOutgoingInvoiceRepository _outgoingInvoiceRepository;
        public GetAllOutgoingInvoicesQueryHandler(IOutgoingInvoiceRepository outgoingInvoiceRepository)
        {
            _outgoingInvoiceRepository = outgoingInvoiceRepository;
        }

        public async Task<List<OutgoingInvoiceViewModel>> Handle(GetAllOutgoingInvoicesQuery request, CancellationToken cancellationToken)
        {
            var outgoingInvoices = await _outgoingInvoiceRepository.GetAllOutgoingInvoicesAsync();

            var outgoingInvoicesViewModel = outgoingInvoices
                .Select(oi => new OutgoingInvoiceViewModel(
                    oi.Id,
                    oi.DepositId,
                    oi.StorageLocationId,
                    oi.ProductId,
                    oi.Quantity,
                    oi.Value)
                ).ToList();

            return outgoingInvoicesViewModel;
        }
    }
}
