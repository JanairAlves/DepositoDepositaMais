using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Core.Entities
{
    public class IncomingOrder : BaseEntity
    {
        public IncomingOrder(int idDeposit, int idStorage, int idProvider, int idRepresentative, int idProduct, int quantity, decimal value, string description, IncomingOrderStatusEnum status, DateTime expectedDeliveryIn)
        {
            IdDeposit = idDeposit;
            IdStorage = idStorage;
            IdProvider = idProvider;
            IdRepresentative = idRepresentative;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = status;
            CreatedAt = DateTime.Now;
            ExpectedDeliveryIn = expectedDeliveryIn;
        }

        public int IdDeposit { get; private set; }
        public int IdStorage { get; private set; }
        public int IdProvider { get; private set; }
        public int IdRepresentative { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public IncomingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpectedDeliveryIn { get; private set; }

        public void Update(int idProduct, int quantity, decimal value, string description, DateTime expectedDeliveryIn) 
        {
            IdProduct = idProduct;
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
