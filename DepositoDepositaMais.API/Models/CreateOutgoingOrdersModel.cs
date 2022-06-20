using System;

namespace DepositoDepositaMais.API.Models
{
    public class CreateOutgoingOrdersModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int QuantityProduct { get; set; }
        public string StatusOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime FinishedIn { get; set; }
        public DateTime CanceledOn { get; set; }
    }
}
