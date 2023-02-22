using DepositoDepositaMais.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Repositories
{
    public interface IProviderRepository
    {
        Task<List<Provider>> GetAllProvidersAsync();
        Task<Provider> GetProviderByIdAsync(int id);
        Task CreateProvider(Provider provider);
        Task SaveChangesAsync();
    }
}
