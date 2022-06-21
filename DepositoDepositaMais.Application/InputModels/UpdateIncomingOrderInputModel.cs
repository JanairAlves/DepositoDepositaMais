using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateIncomingOrderInputModel
    {
        public UpdateIncomingOrderInputModel(int idProduct, int quantity, decimal value, string description, DateTime expectedDeliveryIn)
        {
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
            Description = description;
            ExpectedDeliveryIn = expectedDeliveryIn;
        }

        public int Id { get; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime ExpectedDeliveryIn { get; private set; }
    }
}
