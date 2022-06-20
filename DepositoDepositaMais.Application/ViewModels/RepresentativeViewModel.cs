
namespace DepositoDepositaMais.Application.ViewModels
{
    public class RepresentativeViewModel
    {
        public RepresentativeViewModel(int idProvider, string representativeName, string phoneNumber, string email, string description)
        {
            IdProvider = idProvider;
            RepresentativeName = representativeName;
            PhoneNumber = phoneNumber;
            Email = email;
            Description = description;
        }

        public int IdProvider { get; private set; }
        public string RepresentativeName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; }
    }
}
