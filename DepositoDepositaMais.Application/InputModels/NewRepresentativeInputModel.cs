using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class NewRepresentativeInputModel
    {
        public NewRepresentativeInputModel(int idProvider, string representativeName, DateTime birthday, string cPF, string phoneNumber, string email, string description)
        {
            IdProvider = idProvider;
            RepresentativeName = representativeName;
            Birthday = birthday;
            CPF = cPF;
            PhoneNumber = phoneNumber;
            Email = email;
            Description = description;
            Status = RepresentativeStatusEnum.Active;
            CreatedAt = DateTime.Now;
        }

        public int IdProvider { get; private set; }
        public string RepresentativeName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string CPF { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; }
        public RepresentativeStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
