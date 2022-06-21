using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingInvoiceDetailsViewModel
    {
        public OutgoingInvoiceDetailsViewModel(int id, int idDeposito, int idStorage, int idProduct, int quantity, decimal value, string description, OutgoingOrderStatusEnum status, DateTime createdAt, DateTime submittedIn)
        {
            Id = id;
            IdDeposito = idDeposito;
            IdStorage = idStorage;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            SubmittedIn = submittedIn;
        }

        public int Id { get; }
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
