using DepositoDepositaMais.Core.Enums;
using MediatR;
using System;

namespace DepositoDepositaMais.Application.Commands.CreateIncomingOrder
{
    public class CreateIncomingOrderCommand : IRequest<int>
    {
        public int DepositId { get; private set; }
        public int StorageLocationId { get; private set; }
        public int ProviderId { get; private set; }
        public int RepresentativeId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public IncomingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpectedDeliveryIn { get; private set; }
    }
}
