
namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingOrderViewModel
    {
        public OutgoingOrderViewModel(int id, int idDeposit, int idStoragePlace, int idProduct, int quantity, decimal value)
        {
            Id = id;
            IdDeposit = idDeposit;
            IdStoragePlace = idStoragePlace;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
        }

        public int Id { get; }
        public int IdDeposit { get; private set; }
        public int IdStoragePlace { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
    }
}
