using System;

namespace DepositoDepositaMais.API.Models
{
    public class CreateDepositModel
    {
        public int Id { get; set; }
        public string DepositName { get; set; }
        public string Description { get; set; }
        public string CNPJ { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
