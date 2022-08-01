
namespace DepositoDepositaMais.Core.Entities
{
    public class OutgoingOrderProducts : BaseEntity
    {
        public OutgoingOrderProducts(int idOutgoingOrder, int idProduct)
        {
            IdOutgoingOrder = idOutgoingOrder;
            IdProduct = idProduct;
        }

        public int IdOutgoingOrder { get; private set; }
        public int IdProduct { get; private set; }
        public Product Product { get; private set; }

    }
}