using System;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateOutgoingOrderInputModel
    {
        public UpdateOutgoingOrderInputModel(int idStoragePlace, int idProduct, int quantity, decimal value, string description, DateTime sendIn)
        {
            IdStoragePlace = idStoragePlace;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
            Description = description;
            SendIn = sendIn;
        }

        public int Id { get; }
        public int IdStoragePlace { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public DateTime SendIn { get; private set; }
    }
}
