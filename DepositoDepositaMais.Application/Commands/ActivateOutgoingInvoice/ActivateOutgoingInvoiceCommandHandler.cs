using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateOutgoingInvoice
{
    public class ActivateOutgoingInvoiceCommandHandler : IRequestHandler<ActivateOutgoingInvoiceCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateOutgoingInvoiceCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateOutgoingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices.SingleOrDefault(oi => oi.Id == request.Id);

            outgoingInvoice.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
