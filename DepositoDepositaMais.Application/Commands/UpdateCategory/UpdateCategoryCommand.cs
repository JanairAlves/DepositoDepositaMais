using MediatR;

namespace DepositoDepositaMais.Application.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public int Id { get; }
        public string CategoryName { get; private set; }
        public string Description { get; private set; }
    }
}
