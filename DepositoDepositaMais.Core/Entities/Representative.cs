using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class Representative : BaseEntity
    {
        public Representative(int providerId, string representativeName, DateTime birthday, string cPF, string phoneNumber, string email, string description)
        {
            ProviderId = providerId;
            RepresentativeName = representativeName;
            Birthday = birthday;
            CPF = cPF;
            PhoneNumber = phoneNumber;
            Email = email;
            Description = description;
            Status = RepresentativeStatusEnum.Active;
            CreatedAt = DateTime.Now;
        }

        public string RepresentativeName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string CPF { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; }
        public RepresentativeStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public int ProviderId { get; private set; }
        public Provider Provider { get; private set; }
        public List<IncomingOrder> IncomingOrders { get; private set; }
        public List<OutgoingOrder> OutgoingOrders { get; private set; }

        public void Update(int idProvider, string representativeName, DateTime birthday, string cPF, string phoneNumber, string email, string description)
        {
            ProviderId = idProvider;
            RepresentativeName = representativeName;
            Birthday = birthday;
            CPF = cPF;
            PhoneNumber = phoneNumber;
            Email = email;
            Description = description;
        }

        public void Activate()
        {
            if (Status == RepresentativeStatusEnum.Inactive)
                Status = RepresentativeStatusEnum.Active;
        }

        public void Inactivate()
        {
            if( Status == RepresentativeStatusEnum.Active)
                Status = RepresentativeStatusEnum.Inactive;
        }
    }
}
