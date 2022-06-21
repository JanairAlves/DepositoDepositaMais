using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class DepositDetailsViewModel
    {
        public DepositDetailsViewModel(int idDeposit, string depositName, string description, string cNPJ, DepositStatusEnum status, DateTime createdAt)
        {
            IdDeposit = idDeposit;
            DepositName = depositName;
            Description = description;
            CNPJ = cNPJ;
            Status = status;
            CreatedAt = createdAt;
        }

        public int IdDeposit { get; }
        public string DepositName { get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
        public DepositStatusEnum Status { get; }
        public DateTime CreatedAt { get; }
    }
}
