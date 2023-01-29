using MediatR;

namespace DepositoDepositaMais.Application.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
