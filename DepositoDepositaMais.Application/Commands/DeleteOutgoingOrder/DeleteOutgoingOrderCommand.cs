using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteOutgoingOrder
{
    public class DeleteOutgoingOrderCommand : IRequest<Unit>
    {
        public DeleteOutgoingOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
