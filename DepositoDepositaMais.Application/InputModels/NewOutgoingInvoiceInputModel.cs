using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class NewOutgoingInvoiceInputModel
    {
        public int IdDeposito { get; private set; }
        public int IdStorage { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SubmittedIn { get; private set; }
    }
}
