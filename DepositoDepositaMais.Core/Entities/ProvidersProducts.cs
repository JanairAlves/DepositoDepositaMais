using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class ProvidersProducts : BaseEntity
    {
        public int ProviderId { get; private set; }
        public Provider Provider { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
    }
}
