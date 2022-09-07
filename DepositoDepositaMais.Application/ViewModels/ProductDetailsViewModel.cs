
using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(string productCode, int providerId, string productName, string description, string packagingType, string quantityPackaging, ProductStatusEnum status, DateTime createdAt, int storageLocationId, string street, string categoryName)
        {
            ProductCode = productCode;
            ProviderId = providerId;
            ProductName = productName;
            Description = description;
            PackagingType = packagingType;
            QuantityPackaging = quantityPackaging;
            Status = status;
            CreatedAt = createdAt;

            StorageLocationId = storageLocationId;
            Street = street;
            
            CategoryName = categoryName;
        }

        public string ProductCode { get; private set; }
        public int ProviderId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public string PackagingType { get; private set; }
        public string QuantityPackaging { get; private set; }
        public ProductStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public int StorageLocationId { get; private set; }
        public string Street { get; private set; }

        public string CategoryName { get; private set; }
    }
}
