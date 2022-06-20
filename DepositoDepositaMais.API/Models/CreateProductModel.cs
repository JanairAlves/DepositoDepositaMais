using System;

namespace DepositoDepositaMais.API.Models
{
    public class CreateProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
