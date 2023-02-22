using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateIncomingInvoice
{
    public class ActivateIncomingInvoiceCommandHandler : IRequestHandler<ActivateIncomingInvoiceCommand, Unit>
    {
        private readonly IIncomingInvoiceRepository _incomingInvoiceRepository;
        public ActivateIncomingInvoiceCommandHandler(IIncomingInvoiceRepository incomingInvoiceRepository)
        {
            _incomingInvoiceRepository = incomingInvoiceRepository;
        }

        public async Task<Unit> Handle(ActivateIncomingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var incomingInvoice = await _incomingInvoiceRepository.GetIncomingInvoiceByIdAsync(request.Id);

            incomingInvoice.Activate();

            await _incomingInvoiceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
