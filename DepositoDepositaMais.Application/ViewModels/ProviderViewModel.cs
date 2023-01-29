namespace DepositoDepositaMais.Application.ViewModels
{
    public class ProviderViewModel
    {
        public ProviderViewModel(string providerName, string cNPJ, string site, string emailAddress, string phoneNumber)
        {
            ProviderName = providerName;
            CNPJ = cNPJ;
            Site = site;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }

        public string ProviderName { get; private set; }
        public string CNPJ { get; private set; }
        public string Site { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
