using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateRepresentativeInputModel
    {
        public int Id { get; }
        public int IdProvider { get; private set; }
        public string RepresentativeName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string CPF { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; }
    }
}
