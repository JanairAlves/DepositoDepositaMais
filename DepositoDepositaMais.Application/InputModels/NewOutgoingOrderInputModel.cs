using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class NewOutgoingOrderInputModel
    {
        public int DepositId { get; private set; }
        public int StorageLocationId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SendIn { get; private set; }
    }
}
