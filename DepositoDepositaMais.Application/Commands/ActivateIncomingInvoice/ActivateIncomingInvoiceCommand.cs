using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateIncomingInvoice
{
    public class ActivateIncomingInvoiceCommand : IRequest<Unit>
    {
        public ActivateIncomingInvoiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
