using MediatR;
using System;

namespace DepositoDepositaMais.Application.Commands.UpdateIncomingOrder
{
    public class UpdateIncomingOrderCommand : IRequest<Unit>
    {
        public int Id { get; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime ExpectedDeliveryIn { get; private set; }
    }
}
