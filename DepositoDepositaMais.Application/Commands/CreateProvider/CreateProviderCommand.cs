using DepositoDepositaMais.Core.Enums;
using MediatR;
using System;

namespace DepositoDepositaMais.Application.Commands.CreateProvider
{
    public class CreateProviderCommand : IRequest<int>
    {
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
