using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateDeposit
{
    public class ActivateDepositCommand : IRequest<Unit>
    {
        public ActivateDepositCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
