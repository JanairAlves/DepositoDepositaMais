using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product(string idProduct, int idProvider, string productName, string description, string quantityPackaging, string packagingType)
        {
            IdProduct = idProduct;
            IdProvider = idProvider;
            ProductName = productName;
            Description = description;
            PackagingType = packagingType;
            QuantityPackaging = quantityPackaging;

            CreatedAt = DateTime.Now;
            Status = ProductStatusEnum.Active;
        }

        public string IdProduct { get; private set; }
        public int IdProvider { get; private set; }
        public Provider Provider { get; private set; }
        public int IdIncomingOrder { get; private set; }
        public IncomingOrder IncomingOrder { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public string PackagingType { get; private set; }
        public string QuantityPackaging { get; private set; }
        public ProductStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void Update(string idProduct, int idProvider, string productName, string description, string packagingType, string quantityPackaging)
        {
            IdProduct = idProduct;
            IdProvider = idProvider;
            ProductName = productName;
            Description = description;
            PackagingType = packagingType;
            QuantityPackaging = quantityPackaging;
        }

        public void Activate()
        {
            if (Status == ProductStatusEnum.Inactive)
                Status = ProductStatusEnum.Active;
        }

        public void Inactivate()
        {
            if(Status == ProductStatusEnum.Inactive)
                Status = ProductStatusEnum.Active;
        }
    }
}
