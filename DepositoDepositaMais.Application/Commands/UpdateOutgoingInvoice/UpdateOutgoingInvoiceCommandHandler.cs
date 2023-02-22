using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateOutgoingInvoice
{
    public class UpdateOutgoingInvoiceCommandHandler : IRequestHandler<UpdateOutgoingInvoiceCommand, Unit>
    {
        private readonly IOutgoingInvoiceRepository _outgoingInvoiceRepository;
        public UpdateOutgoingInvoiceCommandHandler(IOutgoingInvoiceRepository outgoingInvoiceRepository)
        {
            _outgoingInvoiceRepository = outgoingInvoiceRepository;
        }

        public async Task<Unit> Handle(UpdateOutgoingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = await _outgoingInvoiceRepository.GetOutgoingInvoiceByIdAsync(request.Id);

            outgoingInvoice.Update(
                request.StorageLocationId,
                request.ProductId,
                request.Quantity,
                request.Value,
                request.Description,
                request.SubmittedIn
                );

            await _outgoingInvoiceRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
