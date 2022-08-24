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
        public OutgoingOrder OutgoingOrder { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }

    }
}