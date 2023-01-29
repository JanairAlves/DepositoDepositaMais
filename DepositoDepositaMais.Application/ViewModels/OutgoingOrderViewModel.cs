namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingOrderViewModel
    {
        public OutgoingOrderViewModel(int id, int depositId, int storageLocationId, int idProduct, int quantity, decimal value)
        {
            Id = id;
            DepositId = depositId;
            StorageLocationId = storageLocationId;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
        }

        public int Id { get; }
        public int DepositId { get; private set; }
        public int StorageLocationId { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
    }
}
