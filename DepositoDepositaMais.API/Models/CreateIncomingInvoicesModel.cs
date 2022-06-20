using System;

namespace DepositoDepositaMais.API.Models
{
    public class CreateIncomingInvoicesModel
    {
        public int InvoiceNumeric { get; set; }
        public string InvoiceStatus { get; set; }
        public int IdOrder { get; set; }
        public int ProviderId { get; set; }
        public int ProductId { get; set; }
        public int QuantityProduct { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
