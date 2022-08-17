using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class OutgoingInvoice : BaseEntity
    {
        public OutgoingInvoice(int depositId, int storagePlaceId, int productId, int quantity, decimal value, string description, DateTime submittedIn)
        {
            DepositId = depositId;
            StoragePlaceId = storagePlaceId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = OutgoingOrderStatusEnum.Active;
            CreatedAt = DateTime.Now;
            SubmittedIn = submittedIn;
        }

        public Deposit Deposit { get; set; }
        public Representative Representative { get; set; }
        public int DepositId { get; private set; }
        public int StoragePlaceId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SubmittedIn { get; private set; }

        public List<OutgoingOrder> OutgoingOrders { get; private set; }

        public void Update(int storagePlaceId, int productId, int quantity, decimal value, string description, DateTime submittedIn)
        {
            StoragePlaceId = storagePlaceId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
            Description = description;
            SubmittedIn = submittedIn;
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
