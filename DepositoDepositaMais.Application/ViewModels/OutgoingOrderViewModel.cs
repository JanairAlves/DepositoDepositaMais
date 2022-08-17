
namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingOrderViewModel
    {
        public OutgoingOrderViewModel(int id, int depositId, int storagePlaceId, int idProduct, int quantity, decimal value)
        {
            Id = id;
            DepositId = depositId;
            StoragePlaceId = storagePlaceId;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
        }

        public int Id { get; }
        public int DepositId { get; private set; }
        public int StoragePlaceId { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
    }
}
