using System.Collections.Generic;

namespace DepositoDepositaMais.Core.Entities
{
    public class ProvidersProducts : BaseEntity
    {
        public int ProviderId { get; private set; }
        public List<Provider> Providers { get; private set; }
        public int ProductId { get; private set; }
        public List<Product> Products { get; private set; }
    }
}
