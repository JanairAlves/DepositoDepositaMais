
namespace DepositoDepositaMais.Application.ViewModels
{
    public class StoragePlaceViewModel
    {
        public StoragePlaceViewModel(int id, int productId, int quantity, string street)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            Street = street;
        }

        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public string Street { get; private set; }

    }
}
