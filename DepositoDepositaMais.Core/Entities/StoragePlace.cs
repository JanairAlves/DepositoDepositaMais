using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class StoragePlace : BaseEntity
    {
        public StoragePlace(int productId, int quantity, int minimumQuantity, int maximumQuantity, string street)
        {
            ProductId = productId;
            Quantity = quantity;
            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Street = street;
        }

        public int StoragePlaceId { get; private set; }
        public int ProductId { get; private set; }
        public List<Product> Product { get; private set; }
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
