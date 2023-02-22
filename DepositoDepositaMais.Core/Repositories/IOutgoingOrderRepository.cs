using DepositoDepositaMais.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Repositories
{
    public interface IOutgoingOrderRepository
    {
        Task<List<OutgoingOrder>> GetAllOutgoingOrdersAsync();
        Task<OutgoingOrder> GetOutgoingOrderByIdAsync(int id);
        Task CreateOutgoingOrder(OutgoingOrder outgoingOrder);
        Task SaveChangesAsync();
    }
}
