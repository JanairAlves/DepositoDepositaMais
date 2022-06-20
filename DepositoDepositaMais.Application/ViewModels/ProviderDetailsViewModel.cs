using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class ProviderDetailsViewModel
    {
        public ProviderDetailsViewModel(int id, string providerName, string description, string cNPJ, string site, string emailAddress, string phoneNumber, ProviderTypeEnum providerType, ProviderStatusEnum status, DateTime createdAt)
        {
            Id = id;
            ProviderName = providerName;
            Description = description;
            CNPJ = cNPJ;
            Site = site;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            ProviderType = providerType;
            Status = status;
            CreatedAt = createdAt;
        }

        public int Id { get; }
        public string ProviderName { get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
        public string Site { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public ProviderTypeEnum ProviderType { get; private set; }
        public ProviderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
