using MediatR;

namespace DepositoDepositaMais.Application.Commands.CreateStorageLocation
{
    public class CreateStorageLocationCommand : IRequest<int>
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public int MinimumQuantity { get; private set; }
        public int MaximumQuantity { get; private set; }
        public string Street { get; private set; }
    }
}
