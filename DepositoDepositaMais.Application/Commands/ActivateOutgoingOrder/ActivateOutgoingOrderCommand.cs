using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateOutgoingOrder
{
    public class ActivateOutgoingOrderCommand : IRequest<Unit>
    {
        public ActivateOutgoingOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
