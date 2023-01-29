using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateIncomingOrder
{
    public class ActivateIncomingOrderCommand : IRequest<Unit>
    {
        public ActivateIncomingOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
