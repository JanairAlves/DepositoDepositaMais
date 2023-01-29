using MediatR;

namespace DepositoDepositaMais.Application.Commands.UpdateStorageLocation
{
    public class UpdateStorageLocationCommand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public int MinimumQuantity { get; private set; }
        public int MaximumQuantity { get; private set; }
        public string Street { get; private set; }
    }
}
