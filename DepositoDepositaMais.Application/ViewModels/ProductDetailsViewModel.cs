
using DepositoDepositaMais.Core.Enums;
using System;

namespace DepositoDepositaMais.Application.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(string idProduct, int idProvider, string productName, string description, string packagingType, string quantityPackaging, ProductStatusEnum status, DateTime createdAt)
        {
            IdProduct = idProduct;
            IdProvider = idProvider;
            ProductName = productName;
            Description = description;
            PackagingType = packagingType;
            QuantityPackaging = quantityPackaging;
            Status = status;
            CreatedAt = createdAt;
        }

        public string IdProduct { get; private set; }
        public int IdProvider { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public string PackagingType { get; private set; }
        public string QuantityPackaging { get; private set; }
        public ProductStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
