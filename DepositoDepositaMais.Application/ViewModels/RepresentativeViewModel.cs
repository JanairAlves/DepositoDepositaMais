
namespace DepositoDepositaMais.Application.ViewModels
{
    public class RepresentativeViewModel
    {
        public RepresentativeViewModel(int providerId, string representativeName, string phoneNumber, string email, string description)
        {
            ProviderId = providerId;
            RepresentativeName = representativeName;
            PhoneNumber = phoneNumber;
            Email = email;
            Description = description;
        }

        public int ProviderId { get; private set; }
        public string RepresentativeName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; }
    }
}
