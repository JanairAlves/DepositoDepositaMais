using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllIncomingInvoices
{
    public class GetAllIncomingInvoicesQueryHandler : IRequestHandler<GetAllIncomingInvoicesQuery, GetAllIncomingInvoicesQuery>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllIncomingInvoicesQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetAllIncomingInvoicesQuery> Handle(GetAllIncomingInvoicesQuery request, CancellationToken cancellationToken)
        {
            var incomingInvoice = _dbContext.IncomingInvoices;

            var incomingInvoiceViewModel = await incomingInvoice
                .Select(ii => new IncomingInvoiceViewModel(
                    ii.Id,
                    ii.CompanyName,
                    ii.CNPJCompany,
                    ii.CPFCompany,
                    ii.CarrierName,
                    ii.CarPlate,
                    ii.CNPJCarrier,
                    ii.CPFCarrier)
                ).ToListAsync();

            return incomingInvoiceViewModel;
        }
    }
}
