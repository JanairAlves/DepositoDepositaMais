
namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingInvoiceViewModel
    {
        public OutgoingInvoiceViewModel(int id, int idDeposito, int idStoragePlace, int idProduct, int quantity, decimal value)
        {
            Id = id;
            IdDeposito = idDeposito;
            IdStoragePlace = idStoragePlace;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
        }

        public int Id { get; }
        public int IdDeposito { get; private set; }
        public int IdStoragePlace { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; set; }
        public decimal Value { get; private set; }
    }
}
