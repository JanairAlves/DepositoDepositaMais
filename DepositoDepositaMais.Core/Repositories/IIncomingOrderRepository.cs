using DepositoDepositaMais.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Repositories
{
    public interface IIncomingOrderRepository
    {
        Task<List<IncomingOrder>> GetAllIncomingOrdersAsync();
        Task<IncomingOrder> GetIncomingOrderByIdAsync(int id);
        Task CreateIncomingOrder(IncomingOrder incomingOrder);
        Task SaveChangesAsync();
    }
}
