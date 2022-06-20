
using DepositoDepositaMais.Core.Enums;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateProviderInputModel
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
