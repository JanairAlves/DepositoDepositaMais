using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateProduct
{
    public class ActivateProductCommand : IRequest<Unit>
    {
        public ActivateProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
