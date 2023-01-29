using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetIncomingInvoiceById
{
    public class GetIncomingInvoiceByIdQueryHandler : IRequestHandler<GetIncomingInvoiceByIdQuery, IncomingInvoiceDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetIncomingInvoiceByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IncomingInvoiceDetailsViewModel> Handle(GetIncomingInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var incomingInvoice = await _dbContext.IncomingInvoices.SingleOrDefaultAsync(ii => ii.Id == request.Id);

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
