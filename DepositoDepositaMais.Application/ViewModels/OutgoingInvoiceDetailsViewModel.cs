using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingInvoiceDetailsViewModel
    {
        public OutgoingInvoiceDetailsViewModel(int id, int depositId, int storagePlaceId, int productId, int quantity, decimal value, string description, OutgoingOrderStatusEnum status, DateTime createdAt, DateTime submittedIn)
        {
            Id = id;
            DepositId = depositId;
            StoragePlaceId = storagePlaceId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            SubmittedIn = submittedIn;
        }

        public int Id { get; }
        public int DepositId { get; private set; }
        public int StoragePlaceId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SubmittedIn { get; private set; }
    }
}
