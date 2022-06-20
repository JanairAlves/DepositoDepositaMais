using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class NewIncomingOrderInputModel
    {
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
    }
}
