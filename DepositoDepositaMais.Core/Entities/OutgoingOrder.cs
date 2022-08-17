using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class OutgoingOrder : BaseEntity
    {
        public OutgoingOrder(int depositId, int storagePlaceId, int productId, int quantity, decimal value, string description, DateTime sendIn)
        {
            DepositId = depositId;
            StoragePlaceId = storagePlaceId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = OutgoingOrderStatusEnum.Active;
            CreatedAt = DateTime.Now;
            SendIn = sendIn;
        }

        public int OutgoingOrderId { get; private set; }
        public int DepositId { get; private set; }
        public Deposit Deposit { get; private set; }
        public int RepresentativeId { get; private set; }
        public Representative Representative { get; private set; }
        public int StoragePlaceId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SendIn { get; private set; }
        public List<OutgoingOrderProducts> OutgoingOrderProducts { get; private set; }

        public void Update(int storagePlaceId, int productId, int quantity, decimal value, string description, DateTime sendIn)
        {
            StoragePlaceId = storagePlaceId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
            Description = description;
            SendIn = sendIn;
        }

        public void Activate()
        {
            if (Status == OutgoingOrderStatusEnum.Active)
                Status = OutgoingOrderStatusEnum.Inactive;
        }

        public void Inactivate()
        {
            if (Status == OutgoingOrderStatusEnum.Inactive)
                Status = OutgoingOrderStatusEnum.Active;
        }
    }
}
