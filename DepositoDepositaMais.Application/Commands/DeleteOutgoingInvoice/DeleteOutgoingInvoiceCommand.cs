using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteOutgoingInvoice
{
    public class DeleteOutgoingInvoiceCommand : IRequest<Unit>
    {
        public DeleteOutgoingInvoiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
