using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class OutgoingOrderDetailsViewModel
    {
        public OutgoingOrderDetailsViewModel(int id, int idDeposit, int idStoragePlace, int idProduct, int quantity, decimal value, string description, OutgoingOrderStatusEnum status, DateTime createdAt, DateTime sendIn)
        {
            Id = id;
            IdDeposit = idDeposit;
            IdStoragePlace = idStoragePlace;
            IdProduct = idProduct;
            Quantity = quantity;
            Value = value;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            SendIn = sendIn;
        }

        public int Id { get; }
        public int IdDeposit { get; private set; }
        public int IdStoragePlace { get; private set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public OutgoingOrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime SendIn { get; private set; }
    }
}
