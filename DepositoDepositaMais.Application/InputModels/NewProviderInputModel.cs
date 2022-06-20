using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.InputModels
{
    public class NewProviderInputModel
    {
        public NewProviderInputModel(string providerName, string description, string cNPJ, string site, string emailAddress, string phoneNumber, ProviderTypeEnum providerType)
        {
            ProviderName = providerName;
            Description = description;
            CNPJ = cNPJ;
            Site = site;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            ProviderType = providerType;
            Status = ProviderStatusEnum.Active;
            CreatedAt = DateTime.Now;
        }

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
