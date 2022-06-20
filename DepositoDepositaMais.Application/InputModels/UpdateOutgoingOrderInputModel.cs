using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateOutgoingOrderInputModel
    {
        public UpdateOutgoingOrderInputModel(int idStorage, int idProduct, int quantity, decimal value, string description, DateTime sendIn)
        {
            IdStorage = idStorage;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
            Description = description;
            SendIn = sendIn;
        }

        public int Id { get; }
        public int IdStorage { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime SendIn { get; private set; }
    }
}
