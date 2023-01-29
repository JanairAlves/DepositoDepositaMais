using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteStorageLocation
{
    public class DeleteStorageLocationCommand : IRequest<Unit>
    {
        public DeleteStorageLocationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
