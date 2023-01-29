using MediatR;
using System;

namespace DepositoDepositaMais.Application.Commands.UpdateOutgoingOrder
{
    public class UpdateOutgoingOrderCommand : IRequest<Unit>
    {
        public int Id { get; }
        public int StorageLocationId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime SendIn { get; private set; }
    }
}
