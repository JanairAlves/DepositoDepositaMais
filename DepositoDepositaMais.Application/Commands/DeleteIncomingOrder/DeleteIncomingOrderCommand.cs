using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteIncomingOrder
{
    public class DeleteIncomingOrderCommand : IRequest<Unit>
    {
        public DeleteIncomingOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
