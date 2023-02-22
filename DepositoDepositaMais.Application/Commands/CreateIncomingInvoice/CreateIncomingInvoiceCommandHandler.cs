using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateIncomingInvoice
{
    public class CreateIncomingInvoiceCommandHandler : IRequestHandler<CreateIncomingInvoiceCommand, int>
    {
        private readonly IIncomingInvoiceRepository _IncomingInvoiceRepository;
        public CreateIncomingInvoiceCommandHandler(IIncomingInvoiceRepository IncomingInvoiceRepository)
        {
            _IncomingInvoiceRepository = IncomingInvoiceRepository;
        }

        public async Task<int> Handle(CreateIncomingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var incomingInvoice = new IncomingInvoice(
                request.CompanyName,
                request.CompanyAddress,
                request.CNPJCompany,
                request.CPFCompany,
                request.CompanyStateRegistration,

                request.CarrierName,
                request.CodeResponsibility,
                request.CarPlate,
                request.CNPJCarrier,
                request.CPFCarrier,
                request.CarrierAdress,
                request.CarrierStateRegistration,

                request.TypeOfVolume,
                request.WeightOfTheCargo,

                request.Description,
                request.ReceivedIn
                );

            await _IncomingInvoiceRepository.CreateIncomingInvoice(incomingInvoice)

            return incomingInvoice.Id;
        }
    }
}
