using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class OutgoingOrderProducts : BaseEntity
    {
        public OutgoingOrderProducts(int outgoingOrderId, int productId)
        {
            OutgoingOrderId = outgoingOrderId;
            ProductId = productId;
        }

        public int OutgoingOrderId { get; private set; }
        public List<OutgoingOrder> OutgoingOrders { get; private set; }
        public int ProductId { get; private set; }
        public List<Product> Products { get; private set; }

    }
}