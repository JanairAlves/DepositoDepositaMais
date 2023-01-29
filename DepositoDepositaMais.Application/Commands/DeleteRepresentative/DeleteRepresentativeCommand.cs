using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteRepresentative
{
    public class DeleteRepresentativeCommand : IRequest<Unit>
    {
        public DeleteRepresentativeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
