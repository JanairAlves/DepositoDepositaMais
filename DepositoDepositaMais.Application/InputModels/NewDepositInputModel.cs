using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class NewDepositInputModel
    {
        public NewDepositInputModel(string depositName, string description, string cNPJ)
        {
            DepositName = depositName;
            Description = description;
            CNPJ = cNPJ;
            Status = 0;
            CreatedAt = DateTime.Now;
        }

        public string DepositName { get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
        public DepositStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
