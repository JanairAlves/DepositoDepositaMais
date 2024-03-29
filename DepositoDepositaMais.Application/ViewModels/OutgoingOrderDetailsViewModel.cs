﻿using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingOrderDetailsViewModel
    {
        public OutgoingOrderDetailsViewModel(int id, int depositId, int storageLocationId, int productId, int quantity, decimal value, string description, OutgoingOrderStatusEnum status, DateTime createdAt, DateTime sendIn, string depositName, string cnpj, string representativeName, string cpf, string phoneNumber, string email)
        {
            Id = id;
            DepositId = depositId;
            StorageLocationId = storageLocationId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            SendIn = sendIn;

            DepositName = depositName;
            CNPJ = cnpj;

            RepresentativeName = representativeName;
            CPF = cpf;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public int Id { get; }
        public int DepositId { get; private set; }
        public int StorageLocationId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SendIn { get; private set; }

        public string DepositName { get; private set; }
        public string CNPJ { get; private set; }

        public string RepresentativeName { get; private set; }
        public string CPF { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
    }
}
