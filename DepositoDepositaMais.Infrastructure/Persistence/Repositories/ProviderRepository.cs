using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ProviderRepository(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Provider>> GetAllProvidersAsync()
        {
            return await _dbContext.Providers.ToListAsync();
        }

        public async Task<Provider> GetProviderByIdAsync(int id)
        {
            return await _dbContext.Providers.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProvider(Provider provider)
        {
            await _dbContext.Providers.AddAsync(provider);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
