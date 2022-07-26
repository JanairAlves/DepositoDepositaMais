
namespace DepositoDepositaMais.Core.Entities
{
    public class StoragePlace : BaseEntity
    {
        public StoragePlace(int idProduct, int quantity, int minimumQuantity, int maximumQuantity, string street)
        {
            IdProduct = idProduct;
            Quantity = quantity;
            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Street = street;
        }

        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public int MinimumQuantity { get; private set; }
        public int MaximumQuantity { get; private set; }
        public string Street { get; private set; }

        public void Update(int quantity, int minimumQuantity, int maximumQuantity, string street)
        {
            Quantity = quantity;
            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Street = street;
        }
    }
}
