using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class StorageDetailsViewModel
    {
        public StorageDetailsViewModel(int id, int idProduct, int quantity, int minimumQuantity, int maximumQuantity, string street)
        {
            Id = id;
            IdProduct = idProduct;
            Quantity = quantity;
            MinimumQuantity = minimumQuantity;
            MaximumQuantity = maximumQuantity;
            Street = street;
        }

        public int Id { get; set; }
        public int IdProduct { get; private set; }
        public int Quantity { get; private set; }
        public int MinimumQuantity { get; private set; }
        public int MaximumQuantity { get; private set; }
        public string Street { get; private set; }
    }
}
