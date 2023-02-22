using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateOutgoingInvoice
{
    public class CreateOutgoingInvoiceCommandHandler : IRequestHandler<CreateOutgoingInvoiceCommand, int>
    {
        private readonly IOutgoingInvoiceRepository _OutgoingInvoiceRepository;
        public CreateOutgoingInvoiceCommandHandler(IOutgoingInvoiceRepository OutgoingInvoiceRepository)
        {
            _OutgoingInvoiceRepository = OutgoingInvoiceRepository;
        }

        public async Task<int> Handle(CreateOutgoingInvoiceCommand request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = new OutgoingInvoice(
                request.DepositId,
                request.StorageLocationId,
                request.ProductId,
                request.Quantity,
                request.Value,
                request.Description,
                request.SubmittedIn
                );

            await _OutgoingInvoiceRepository.CreateOutgoingInvoice(outgoingInvoice);

            return outgoingInvoice.Id;
        }
    }
}
