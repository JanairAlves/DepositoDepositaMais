using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
