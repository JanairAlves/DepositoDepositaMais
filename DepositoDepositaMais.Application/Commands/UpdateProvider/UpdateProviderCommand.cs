using DepositoDepositaMais.Core.Enums;
using MediatR;

namespace DepositoDepositaMais.Application.Commands.UpdateProvider
{
    public class UpdateProviderCommand : IRequest<Unit>
    {
        public int Id { get; }
        public string providerName { get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
        public string Site { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public ProviderTypeEnum ProviderType { get; private set; }
    }
}
