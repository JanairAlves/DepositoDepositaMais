using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateOutgoingOrderInputModel
    {
        public UpdateOutgoingOrderInputModel(int storagePlaceId, int productId, int quantity, decimal value, string description, DateTime sendIn)
        {
            StoragePlaceId = storagePlaceId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
            Description = description;
            SendIn = sendIn;
        }

        public int Id { get; }
        public int StoragePlaceId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime SendIn { get; private set; }
    }
}
