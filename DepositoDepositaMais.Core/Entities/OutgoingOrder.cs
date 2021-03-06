using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class OutgoingOrder : BaseEntity
    {
        public OutgoingOrder(int idDeposit, int idStoragePlace, int idProduct, int quantity, decimal value, string description, DateTime sendIn)
        {
            IdDeposit = idDeposit;
            IdStoragePlace = idStoragePlace;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = OutgoingOrderStatusEnum.Active;
            CreatedAt = DateTime.Now;
            SendIn = sendIn;
        }

        public int IdOutgoingOrder { get; private set; }
        public int IdDeposit { get; private set; }
        public Deposit Deposit { get; private set; }
        public int IdRepresentative { get; private set; }
        public Representative Representative { get; private set; }
        public List<OutgoingOrderProducts> OutgoingOrderProducts { get; private set; }
        public int IdStoragePlace { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SendIn { get; private set; }

        public void Update(int idStoragePlace, int idProduct, int quantity, decimal value, string description, DateTime sendIn)
        {
            IdStoragePlace = idStoragePlace;
            IdProduct = idProduct;
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
