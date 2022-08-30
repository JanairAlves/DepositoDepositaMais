
namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingInvoiceViewModel
    {
        public OutgoingInvoiceViewModel(int id, int depositId, int storageLocationId, int productId, int quantity, decimal value)
        {
            Id = id;
            DepositId = depositId;
            StorageLocationId = storageLocationId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
        }

        public int Id { get; }
        public int DepositId { get; private set; }
        public int StorageLocationId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; set; }
        public decimal Value { get; private set; }
    }
}
