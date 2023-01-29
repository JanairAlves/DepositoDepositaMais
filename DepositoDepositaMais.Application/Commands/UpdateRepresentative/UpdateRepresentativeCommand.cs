using MediatR;
using System;

namespace DepositoDepositaMais.Application.Commands.UpdateRepresentative
{
    public class UpdateRepresentativeCommand : IRequest<Unit>
    {
        public int Id { get; }
        public int ProviderId { get; private set; }
        public string RepresentativeName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string CPF { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Description { get; private set; }
    }
}
