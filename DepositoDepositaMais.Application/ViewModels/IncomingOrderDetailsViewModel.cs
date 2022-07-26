using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class IncomingOrderDetailsViewModel
    {
        public IncomingOrderDetailsViewModel(int id, int idDeposit, int idRepresentative, int quantity, decimal value, string description, IncomingOrderStatusEnum status, DateTime createdAt, DateTime expectedDeliveryIn)
        {
            Id = id;
            IdDeposit = idDeposit;
            IdRepresentative = idRepresentative;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            ExpectedDeliveryIn = expectedDeliveryIn;
        }

        public int Id { get; }
        public int IdDeposit { get; private set; }
        public int IdRepresentative { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public IncomingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpectedDeliveryIn { get; private set; }
    }
}
