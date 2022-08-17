using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Entities
{
    public class Provider : BaseEntity
    {
        public Provider(string providerName, string description, string cNPJ, string site, string emailAddress, string phoneNumber, ProviderTypeEnum providerType)
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

        public int ProviderId { get; private set; }
        public string ProviderName{ get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
        public string Site { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public ProviderTypeEnum ProviderType { get; private set; }
        public ProviderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<ProvidersProducts> ProvidersProducts { get; private set; }
        public List<Representative> Representative { get; private set; }

        public void Update(string providerName, string description, string cNPJ, string site, string emailAddress, string phoneNumber, ProviderTypeEnum providerType)
        {
            ProviderName = providerName;
            Description = description;
            CNPJ = cNPJ;
            Site = site;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            ProviderType = providerType;
        }

        public void Activate()
        {
            if (Status == ProviderStatusEnum.Active)
                Status = ProviderStatusEnum.Inactive;
        }

        public void Inactivate()
        {
            if (Status == ProviderStatusEnum.Inactive)
                Status = ProviderStatusEnum.Active;
        }
    }
}
