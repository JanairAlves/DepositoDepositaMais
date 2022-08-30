using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateOutgoingOrderInputModel
    {
        public UpdateOutgoingOrderInputModel(int storageLocationId, int productId, int quantity, decimal value, string description, DateTime sendIn)
        {
            StorageLocationId = storageLocationId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
            Description = description;
            SendIn = sendIn;
        }

        public int Id { get; }
        public int StorageLocationId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime SendIn { get; private set; }
    }
}
