using MediatR;

namespace DepositoDepositaMais.Application.Commands.ActivateCategory
{
    public class ActivateCategoryCommand : IRequest<Unit>
    {
        public ActivateCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
