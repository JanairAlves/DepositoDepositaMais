using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateIncomingInvoice
{
    public class ActivateIncomingInvoiceCommandHandler : IRequestHandler<ActivateIncomingInvoiceCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateIncomingInvoiceCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateIncomingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var incomingInvoice = _dbContext.IncomingInvoices.SingleOrDefault(ii => ii.Id == request.Id);
            incomingInvoice.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
