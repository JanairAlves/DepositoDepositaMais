using DepositoDepositaMais.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Repositories
{
    public interface IRepresentativeRepository
    {
        Task<List<Representative>> GetAllRepresentativesAsync();
        Task<Representative> GetRepresentativeByIdAsync(int id);
        Task CreateRepresentative(Representative representative);
        Task SaveChangesAsync();
    }
}
