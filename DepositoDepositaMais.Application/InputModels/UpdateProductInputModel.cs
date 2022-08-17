
namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateProductInputModel
    {
        public int Id { get; }
        public string ProductId { get; private set; }
        public int ProviderId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public string PackagingType { get; private set; }
        public string QuantityPackaging { get; private set; }
    }
}
