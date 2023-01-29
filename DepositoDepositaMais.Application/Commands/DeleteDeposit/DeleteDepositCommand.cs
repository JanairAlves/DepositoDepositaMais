using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteDeposit
{
    public class DeleteDepositCommand : IRequest<Unit>
    {
        public DeleteDepositCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
