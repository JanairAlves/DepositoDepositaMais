using DepositoDepositaMais.Core.Enums;
using System;
using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product(string productId, int providerId, string productName, string description, string quantityPackaging, string packagingType)
        {
            ProductId = productId;
            ProviderId = providerId;
            ProductName = productName;
            Description = description;
            PackagingType = packagingType;
            QuantityPackaging = quantityPackaging;

            CreatedAt = DateTime.Now;
            Status = ProductStatusEnum.Active;
        }

        public string ProductId { get; private set; }
        public int ProviderId { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public string PackagingType { get; private set; }
        public string QuantityPackaging { get; private set; }
        public ProductStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<OutgoingOrderProducts> OutgoingOrderProducts { get; private set; }
        public List<IncomingOrderProducts> IncomingOrderProducts { get; private set; }
        public List<ProvidersProducts> ProvidersProducts { get; private set; }

        public void Update(string productId, int providerId, string productName, string description, string packagingType, string quantityPackaging)
        {
            ProductId = productId;
            ProviderId = providerId;
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
