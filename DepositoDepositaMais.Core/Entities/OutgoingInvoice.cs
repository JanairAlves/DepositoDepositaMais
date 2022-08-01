using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class OutgoingInvoice : BaseEntity
    {
        public OutgoingInvoice(int idDeposit, int idStoragePlace, int idProduct, int quantity, decimal value, string description, DateTime submittedIn)
        {
            IdDeposit = idDeposit;
            IdStoragePlace = idStoragePlace;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = OutgoingOrderStatusEnum.Active;
            CreatedAt = DateTime.Now;
            SubmittedIn = submittedIn;
        }

        public Deposit Deposit { get; set; }
        public Representative Representative { get; set; }
        public int IdDeposit { get; private set; }
        public int IdStoragePlace { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SubmittedIn { get; private set; }

        public List<OutgoingOrder> OutgoingOrders { get; private set; }

        public void Update(int idStoragePlace, int idProduct, int quantity, decimal value, string description, DateTime submittedIn)
        {
            IdStoragePlace = idStoragePlace;
            IdProduct = idProduct;
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
