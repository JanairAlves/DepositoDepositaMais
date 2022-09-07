using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class IncomingOrderDetailsViewModel
    {
        public IncomingOrderDetailsViewModel(int id, int depositId, int representativeId, int quantity, decimal value, string description, IncomingOrderStatusEnum status, DateTime createdAt, DateTime expectedDeliveryIn, string depositName, string cnpj, string representativeName, string cpf, string phoneNumber, string email)
        {
            Id = id;
            DepositId = depositId;
            RepresentativeId = representativeId;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            ExpectedDeliveryIn = expectedDeliveryIn;

            DepositName = depositName;
            CNPJ = cnpj;

            RepresentativeName = representativeName;
            CPF = cpf;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public int Id { get; }
        public int DepositId { get; private set; }
        public int RepresentativeId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public IncomingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpectedDeliveryIn { get; private set; }

        public string DepositName { get; private set; }
        public string CNPJ { get; private set; }

        public string RepresentativeName { get; private set; }
        public string CPF { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
    }
}
