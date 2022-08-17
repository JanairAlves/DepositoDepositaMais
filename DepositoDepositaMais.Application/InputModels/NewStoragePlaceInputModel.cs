
namespace DepositoDepositaMais.Application.InputModels
{
    public class NewStoragePlaceInputModel
    {
        public NewStoragePlaceInputModel(int productId, int quantity, int minimumQuantity, int maximumQuantity, string street)
        {
            ProductId = productId;
            Quantity = quantity;
            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Street = street;
        }

        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public int MinimumQuantity { get; private set; }
        public int MaximumQuantity { get; private set; }
        public string Street { get; private set; }
    }
}
