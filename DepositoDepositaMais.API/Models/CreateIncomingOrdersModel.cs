using System;

namespace DepositoDepositaMais.API.Models
{
    public class CreateIncomingOrdersModel
    {
        public int Id { get; set; }
        public int RepresentativeId { get; set; }
        public int ProductId { get; set; }
        public int QuantityProduct { get; set; }
        public decimal ProductPrice { get; set; }
        public string StatusOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime FinishedIn { get; set; }
        public DateTime CanceledOn { get; set; }
    }
}
