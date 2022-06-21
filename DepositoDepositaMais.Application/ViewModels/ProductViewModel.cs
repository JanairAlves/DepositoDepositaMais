
namespace DepositoDepositaMais.Application.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(string idProduct, int idProvider, string productName, string packagingType, string quantityPackaging)
        {
            IdProduct = idProduct;
            IdProvider = idProvider;
            ProductName = productName;
            PackagingType = packagingType;
            QuantityPackaging = quantityPackaging;
        }

        public string IdProduct { get; private set; }
        public int IdProvider { get; private set; }
        public string ProductName { get; private set; }
        public string PackagingType { get; private set; }
        public string QuantityPackaging { get; private set; }
    }
}
