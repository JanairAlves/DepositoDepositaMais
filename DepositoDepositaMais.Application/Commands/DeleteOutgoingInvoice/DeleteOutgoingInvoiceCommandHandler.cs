using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteOutgoingInvoice
{
    public class DeleteOutgoingInvoiceCommandHandler : IRequestHandler<DeleteOutgoingInvoiceCommand, Unit>
    {
        private readonly IOutgoingInvoiceRepository _outgoingInvoiceRepository;
        public DeleteOutgoingInvoiceCommandHandler(IOutgoingInvoiceRepository outgoingInvoiceRepository)
        {
            _outgoingInvoiceRepository = outgoingInvoiceRepository;
        }

        public async Task<Unit> Handle(DeleteOutgoingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = await _outgoingInvoiceRepository.GetOutgoingInvoiceByIdAsync(request.Id);

            outgoingInvoice.Inactivate();

            await _outgoingInvoiceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
