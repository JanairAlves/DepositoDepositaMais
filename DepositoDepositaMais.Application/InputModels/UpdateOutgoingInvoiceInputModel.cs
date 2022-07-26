using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateOutgoingInvoiceInputModel
    {
        public int Id { get; }
        public int IdStoragePlace { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime SubmittedIn { get; private set; }
    }
}
