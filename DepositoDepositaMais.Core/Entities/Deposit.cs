using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class Deposit : BaseEntity
    {
        public Deposit(string depositName, string description, string cNPJ)
        {
            DepositName = depositName;
            Description = description;
            CNPJ = cNPJ;
            Status = DepositStatusEnum.Active;
            CreatedAt = DateTime.Now;
        }

        public string DepositName { get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
        public DepositStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
        public List<StorageLocation> StorageLocations { get; private set; }
        public List<Provider> Providers { get; private set; }
        public List<IncomingOrder> IncomingOrders { get; private set; }
        public List<OutgoingOrder> OutgoingOrders { get; private set; }
        public List<User> Users { get; private set; }

        public void Update(string depositName, string description, string cNPJ)
        {
            DepositName = depositName;
            Description = description;
            CNPJ = cNPJ;
        }

        public void Activate()
        {
            if (Status == DepositStatusEnum.Inactive)
                Status = DepositStatusEnum.Active;
        }

        public void Inactivate()
        {
            if(Status == DepositStatusEnum.Active)
                Status = DepositStatusEnum.Inactive;
        }

    }
}
