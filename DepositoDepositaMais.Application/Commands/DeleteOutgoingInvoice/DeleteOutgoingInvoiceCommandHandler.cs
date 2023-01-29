using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteOutgoingInvoice
{
    public class DeleteOutgoingInvoiceCommandHandler : IRequestHandler<DeleteOutgoingInvoiceCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public DeleteOutgoingInvoiceCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteOutgoingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices.SingleOrDefault(oi => oi.Id == request.Id);

            outgoingInvoice.Inactivate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
