using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateOutgoingInvoice
{
    public class ActivateOutgoingInvoiceCommandHandler : IRequestHandler<ActivateOutgoingInvoiceCommand, Unit>
    {
        private readonly IOutgoingInvoiceRepository _outgoingInvoiceRepository;
        public ActivateOutgoingInvoiceCommandHandler(IOutgoingInvoiceRepository outgoingInvoiceRepository)
        {
            _outgoingInvoiceRepository = outgoingInvoiceRepository;
        }

        public async Task<Unit> Handle(ActivateOutgoingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = await _outgoingInvoiceRepository.GetOutgoingInvoiceByIdAsync(request.Id);

            outgoingInvoice.Activate();

            await _outgoingInvoiceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
