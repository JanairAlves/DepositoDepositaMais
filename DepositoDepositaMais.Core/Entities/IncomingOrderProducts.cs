
namespace DepositoDepositaMais.Core.Entities
{
    public class IncomingOrderProducts : BaseEntity
    {
        public IncomingOrderProducts(int idIncomingOrder, int idProduct)
        {
            IdIncomingOrder = idIncomingOrder;
            IdProduct = idProduct;
        }

        public int IdIncomingOrder { get; private set; }
        public int IdProduct { get; private set; }
        public Product Product { get; private set; }
    }
}
