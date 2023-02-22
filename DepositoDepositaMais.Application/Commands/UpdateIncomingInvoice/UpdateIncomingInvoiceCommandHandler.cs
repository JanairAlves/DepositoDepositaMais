using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateIncomingInvoice
{
    public class UpdateIncomingInvoiceCommandHandler : IRequestHandler<UpdateIncomingInvoiceCommand, Unit>
    {
        private readonly IIncomingInvoiceRepository _incomingInvoiceRepository;
        public UpdateIncomingInvoiceCommandHandler(IIncomingInvoiceRepository incomingInvoiceRepository)
        {
            _incomingInvoiceRepository = incomingInvoiceRepository;
        }

        public async Task<Unit> Handle(UpdateIncomingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var incomingInvoice = await _incomingInvoiceRepository.GetIncomingInvoiceByIdAsync(request.Id);

            incomingInvoice.Update(
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

                request.Status,
                request.Description,
                request.ReceivedIn
                );

            await _incomingInvoiceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
