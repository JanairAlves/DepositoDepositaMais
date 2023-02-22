using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteIncomingInvoice
{
    public class DeleteIncomingInvoiceCommandHandler : IRequestHandler<DeleteIncomingInvoiceCommand, Unit>
    {
        private readonly IIncomingInvoiceRepository _incomingInvoiceRepository;
        public DeleteIncomingInvoiceCommandHandler(IIncomingInvoiceRepository incomingInvoiceRepository) 
        {
            _incomingInvoiceRepository = incomingInvoiceRepository;
        }

        public async Task<Unit> Handle(DeleteIncomingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var incomingInvoice = await _incomingInvoiceRepository.GetIncomingInvoiceByIdAsync(request.Id);

            incomingInvoice.Inactivate();

            await _incomingInvoiceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
