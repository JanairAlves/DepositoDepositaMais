using DepositoDepositaMais.Core.Enums;
using MediatR;
using System;

namespace DepositoDepositaMais.Application.Commands.CreateDeposit
{
    public class CreateDepositCommand : IRequest<int>
    {
        public string DepositName { get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
        public DepositStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
