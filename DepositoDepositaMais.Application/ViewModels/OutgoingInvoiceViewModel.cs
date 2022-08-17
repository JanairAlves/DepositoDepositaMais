
namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingInvoiceViewModel
    {
        public OutgoingInvoiceViewModel(int id, int depositId, int storagePlaceId, int productId, int quantity, decimal value)
        {
            Id = id;
            DepositId = depositId;
            StoragePlaceId = storagePlaceId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
        }

        public int Id { get; }
        public int DepositId { get; private set; }
        public int StoragePlaceId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; set; }
        public decimal Value { get; private set; }
    }
}
