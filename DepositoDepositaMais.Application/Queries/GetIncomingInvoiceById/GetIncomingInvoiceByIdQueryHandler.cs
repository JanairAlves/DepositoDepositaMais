using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetIncomingInvoiceById
{
    public class GetIncomingInvoiceByIdQueryHandler : IRequestHandler<GetIncomingInvoiceByIdQuery, IncomingInvoiceDetailsViewModel>
    {
        private readonly IIncomingInvoiceRepository _incomingInvoiceRepository;
        public GetIncomingInvoiceByIdQueryHandler(IIncomingInvoiceRepository incomingInvoiceRepository)
        {
            _incomingInvoiceRepository = incomingInvoiceRepository;
        }

        public async Task<IncomingInvoiceDetailsViewModel> Handle(GetIncomingInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var incomingInvoice = await _incomingInvoiceRepository.GetIncomingInvoiceByIdAsync(request.Id);

            var incomingInvoiceDetailsViewModel = new IncomingInvoiceDetailsViewModel(
                incomingInvoice.Id,
                incomingInvoice.CompanyName,
                incomingInvoice.CompanyAddress,
                incomingInvoice.CNPJCompany,
                incomingInvoice.CPFCompany,
                incomingInvoice.CompanyStateRegistration,
                incomingInvoice.CarrierName,
                incomingInvoice.CodeResponsibility,
                incomingInvoice.CarPlate,
                incomingInvoice.CNPJCarrier,
                incomingInvoice.CPFCarrier,
                incomingInvoice.CarrierAdress,
                incomingInvoice.CarrierStateRegistration,

                incomingInvoice.TypeOfVolume,
                incomingInvoice.WeightOfTheCargo
                );

            return incomingInvoiceDetailsViewModel;
        }
    }
}
