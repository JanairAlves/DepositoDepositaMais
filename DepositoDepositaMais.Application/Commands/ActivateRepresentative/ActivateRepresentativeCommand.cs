using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateRepresentative
{
    public class ActivateRepresentativeCommand : IRequest<Unit>
    {
        public ActivateRepresentativeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
