using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateIncomingInvoice
{
    public class UpdateIncomingInvoiceCommandHandler : IRequestHandler<UpdateIncomingInvoiceCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateIncomingInvoiceCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateIncomingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var incomingInvoice = _dbContext.IncomingInvoices.SingleOrDefault(ii => ii.Id == request.Id);

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

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
