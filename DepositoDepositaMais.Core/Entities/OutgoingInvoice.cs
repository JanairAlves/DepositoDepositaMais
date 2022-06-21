using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Core.Entities
{
    public class OutgoingInvoice : BaseEntity
    {
        public OutgoingInvoice(int idDeposito, int idStorage, int idProduct, int quantity, decimal value, string description, DateTime submittedIn)
        {
            IdDeposito = idDeposito;
            IdStorage = idStorage;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = OutgoingOrderStatusEnum.Active;
            CreatedAt = DateTime.Now;
            SubmittedIn = submittedIn;
        }

        public int IdDeposito { get; private set; }
        public int IdStorage { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SubmittedIn { get; private set; }

        public void Update(int idStorage, int idProduct, int quantity, decimal value, string description, DateTime submittedIn)
        {
            IdStorage = idStorage;
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
