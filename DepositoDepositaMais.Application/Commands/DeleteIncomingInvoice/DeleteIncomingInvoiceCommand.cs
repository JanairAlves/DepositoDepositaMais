using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteIncomingInvoice
{
    public class DeleteIncomingInvoiceCommand : IRequest<Unit>
    {
        public DeleteIncomingInvoiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
