using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class IncomingOrderProducts : BaseEntity
    {
        public IncomingOrderProducts(int incomingOrderId, int productId)
        {
            IncomingOrderId = incomingOrderId;
            ProductId = productId;
        }

        public int IncomingOrderId { get; private set; }
        public List<IncomingOrder> IncomingOrders { get; private set; }
        public int ProductId { get; private set; }
        public List<Product> Products { get; private set; }
    }
}