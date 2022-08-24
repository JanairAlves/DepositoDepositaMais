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
        public IncomingOrder IncomingOrder { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
    }
}