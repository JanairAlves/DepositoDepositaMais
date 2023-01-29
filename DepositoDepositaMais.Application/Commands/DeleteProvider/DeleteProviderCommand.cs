using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteProvider
{
    public class DeleteProviderCommand : IRequest<Unit>
    {
        public DeleteProviderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
