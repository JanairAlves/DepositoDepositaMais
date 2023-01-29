using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteIncomingInvoice
{
    public class DeleteIncomingInvoiceCommandHandler : IRequestHandler<DeleteIncomingInvoiceCommand, Unit>
    {
        private DepositoDepositaMaisDbContext _dbContext;
        public DeleteIncomingInvoiceCommandHandler(DepositoDepositaMaisDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteIncomingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var incomingInvoice = _dbContext.IncomingInvoices.SingleOrDefault(ii => ii.Id == request.Id);

            incomingInvoice.Inactivate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
