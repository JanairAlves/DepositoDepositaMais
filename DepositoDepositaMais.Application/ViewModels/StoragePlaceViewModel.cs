
namespace DepositoDepositaMais.Application.ViewModels
{
    public class StoragePlaceViewModel
    {
        public StoragePlaceViewModel(int id, int idProduct, int quantity, string street)
        {
            Id = id;
            IdProduct = idProduct;
            Quantity = quantity;
            Street = street;
        }

        public int Id { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public string Street { get; private set; }

    }
}
