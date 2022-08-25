
namespace DepositoDepositaMais.Application.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(string productCode, int providerId, string productName, string packagingType, string quantityPackaging)
        {
            ProductCode = productCode;
            ProviderId = providerId;
            ProductName = productName;
            PackagingType = packagingType;
            QuantityPackaging = quantityPackaging;
        }

        public string ProductCode { get; private set; }
        public int ProviderId { get; private set; }
        public string ProductName { get; private set; }
        public string PackagingType { get; private set; }
        public string QuantityPackaging { get; private set; }
    }
}
