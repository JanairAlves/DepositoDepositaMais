using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllIncomingInvoices
{
    public class GetAllIncomingInvoicesQueryHandler : IRequestHandler<GetAllIncomingInvoicesQuery, List<IncomingInvoiceViewModel>>
    {
        private readonly IIncomingInvoiceRepository incomingInvoiceRepository;
        public GetAllIncomingInvoicesQueryHandler(IIncomingInvoiceRepository incomingInvoiceRepository)
        {
            this.incomingInvoiceRepository = incomingInvoiceRepository;
        }

        public async Task<List<IncomingInvoiceViewModel>> Handle(GetAllIncomingInvoicesQuery request, CancellationToken cancellationToken)
        {
            var incomingInvoices = await incomingInvoiceRepository.GetAllIncomingInvoicesAsync();

            var incomingInvoicesViewModel = incomingInvoices
                .Select(ii => new IncomingInvoiceViewModel(
                    ii.Id,
                    ii.CompanyName,
                    ii.CNPJCompany,
                    ii.CPFCompany,
                    ii.CarrierName,
                    ii.CarPlate,
                    ii.CNPJCarrier,
                    ii.CPFCarrier)
                ).ToList();

            return incomingInvoicesViewModel;
        }
    }
}
