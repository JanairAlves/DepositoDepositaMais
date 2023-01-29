using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateOutgoingInvoice
{
    public class ActivateOutgoingInvoiceCommand : IRequest<Unit>
    {
        public ActivateOutgoingInvoiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
