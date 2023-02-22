using DepositoDepositaMais.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Repositories
{
    public interface IDepositRepository
    {
        Task<List<Deposit>> GetAllDepositsAsync();
        Task<Deposit> GetDepositByIdAsync(int id);
        Task CreateDepositAsync(Deposit deposit);
        Task SaveChangesAsync();
    }
}
