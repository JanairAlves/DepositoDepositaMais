﻿using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class RepresentativeDetailsViewModel
    {
        public RepresentativeDetailsViewModel(int id, int providerId, string representativeName, DateTime birthday, string cPF, string phoneNumber, string email, string description, RepresentativeStatusEnum status, DateTime createdAt, string providerName, string cnpj)
        {
            Id = id;
            ProviderId = providerId;
            RepresentativeName = representativeName;
            Birthday = birthday;
            CPF = cPF;
            PhoneNumber = phoneNumber;
            Email = email;
            Description = description;
            Status = status;
            CreatedAt = createdAt;

            ProviderName = providerName;
            CNPJ = cnpj;
        }

        public int Id { get; private set; }
        public int ProviderId { get; private set; }
        public string RepresentativeName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string CPF { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; }
        public RepresentativeStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public string ProviderName { get; private set; }
        public string CNPJ { get; private set; }
    }
}
