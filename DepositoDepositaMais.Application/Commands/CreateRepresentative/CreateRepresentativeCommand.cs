using DepositoDepositaMais.Core.Enums;
using MediatR;
using System;

namespace DepositoDepositaMais.Application.Commands.CreateRepresentative
{
    public class CreateRepresentativeCommand : IRequest<int>
    {
        public int ProviderId { get; private set; }
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
