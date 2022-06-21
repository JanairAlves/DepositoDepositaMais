
namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingOrderViewModel
    {
        public OutgoingOrderViewModel(int id, int idDeposit, int idStorage, int idProduct, int quantity, decimal value)
        {
            Id = id;
            IdDeposit = idDeposit;
            IdStorage = idStorage;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
        }

        public int Id { get; }
        public int IdDeposit { get; private set; }
        public int IdStorage { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
    }
}
