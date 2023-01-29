using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateStorageLocation
{
    public class ActivateStorageLocationCommand : IRequest<Unit>
    {
        public ActivateStorageLocationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
