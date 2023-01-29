using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateIncomingInvoice
{
    public class CreateIncomingInvoiceCommandHandler : IRequestHandler<CreateIncomingInvoiceCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateIncomingInvoiceCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
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

            await _dbContext.IncomingInvoices.AddAsync(incomingInvoice);
            await _dbContext.SaveChangesAsync();

            return incomingInvoice.Id;
        }
    }
}
