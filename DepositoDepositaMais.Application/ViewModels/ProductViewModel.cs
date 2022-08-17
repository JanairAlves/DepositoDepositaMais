
namespace DepositoDepositaMais.Application.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(string productId, int providerId, string productName, string packagingType, string quantityPackaging)
        {
            ProductId = productId;
            ProviderId = providerId;
            ProductName = productName;
            PackagingType = packagingType;
            QuantityPackaging = quantityPackaging;
        }

        public string ProductId { get; private set; }
        public int ProviderId { get; private set; }
        public string ProductName { get; private set; }
        public string PackagingType { get; private set; }
        public string QuantityPackaging { get; private set; }
    }
}
