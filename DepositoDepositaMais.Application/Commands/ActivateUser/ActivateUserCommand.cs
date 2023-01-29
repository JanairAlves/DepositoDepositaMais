using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateUser
{
    public class ActivateUserCommand : IRequest<Unit>
    {
        public ActivateUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
