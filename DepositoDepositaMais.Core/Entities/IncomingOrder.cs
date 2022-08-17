using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class IncomingOrder : BaseEntity
    {
        public IncomingOrder(int depositId, int representativeId, int quantity, decimal value, string description, IncomingOrderStatusEnum status, DateTime expectedDeliveryIn)
        {
            DepositId = depositId;
            RepresentativeId = representativeId;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = status;
            CreatedAt = DateTime.Now;
            ExpectedDeliveryIn = expectedDeliveryIn;
        }

        public int IncomingOrderId { get; private set; }
        public int DepositId { get; private set; }
        public Deposit Deposit { get; private set; }
        public int RepresentativeId { get; private set; }
        public Representative Representative { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public IncomingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpectedDeliveryIn { get; private set; }
        public List<IncomingOrderProducts> IncomingOrderProducts { get; private set; }

        public void Update(int quantity, decimal value, string description, DateTime expectedDeliveryIn) 
        {
            Quantity = quantity;
            Value = value;
            Description = description;
            ExpectedDeliveryIn = expectedDeliveryIn;
        }

        public void Activate()
        {
            if (Status == IncomingOrderStatusEnum.Inactive)
                Status = IncomingOrderStatusEnum.Active;
        }

        public void Inactivate()
        {
            if(Status == IncomingOrderStatusEnum.Active)
                Status = IncomingOrderStatusEnum.Inactive;
        }

    }
}
