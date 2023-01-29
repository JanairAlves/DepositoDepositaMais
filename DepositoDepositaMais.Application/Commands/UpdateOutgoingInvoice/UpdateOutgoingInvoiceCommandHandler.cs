using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateOutgoingInvoice
{
    public class UpdateOutgoingInvoiceCommandHandler : IRequestHandler<UpdateOutgoingInvoiceCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateOutgoingInvoiceCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateOutgoingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices.SingleOrDefault(oi => oi.Id == request.Id);

            outgoingInvoice.Update(
                request.StorageLocationId,
                request.ProductId,
                request.Quantity,
                request.Value,
                request.Description,
                request.SubmittedIn
                );

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
