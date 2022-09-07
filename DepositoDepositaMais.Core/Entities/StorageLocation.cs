using DepositoDepositaMais.Core.Enums;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class StorageLocation : BaseEntity
    {
        public StorageLocation(int productId, int quantity, int minimumQuantity, int maximumQuantity, string street)
        {
            ProductId = productId;
            Quantity = quantity;
            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Street = street;
            Status = StorageLocationEnum.Active;
        }

        public int Quantity { get; private set; }
        public int MinimumQuantity { get; private set; }
        public int MaximumQuantity { get; private set; }
        public string Street { get; private set; }
        public StorageLocationEnum Status { get; private set; }
        
        public int DepositId { get; private set; }
        public Deposit Deposit { get; private set; }
        public int ProductId { get; private set; }
        public List<Product> Products { get; private set; }

        public void Update(int quantity, int minimumQuantity, int maximumQuantity, string street)
        {
            Quantity = quantity;
            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Street = street;
        }

        public void Activate()
        {
            if (Status == StorageLocationEnum.Inactive)
                Status = StorageLocationEnum.Active;
        }

        public void Inactivate()
        {
            if (Status == StorageLocationEnum.Active)
                Status = StorageLocationEnum.Inactive;
        }
    }
}
