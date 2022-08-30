
namespace DepositoDepositaMais.Application.ViewModels
{
    public class StorageLocationDetailsViewModel
    {
        public StorageLocationDetailsViewModel(int id, int productId, int quantity, int minimumQuantity, int maximumQuantity, string street)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Street = street;
        }

        public int Id { get; set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public int MinimumQuantity { get; private set; }
        public int MaximumQuantity { get; private set; }
        public string Street { get; private set; }
    }
}
