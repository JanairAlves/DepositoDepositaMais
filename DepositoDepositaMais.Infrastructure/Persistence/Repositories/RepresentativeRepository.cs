using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Repositories
{
    public class RepresentativeRepository : IRepresentativeRepository
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public RepresentativeRepository(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Representative>> GetAllRepresentativesAsync()
        {
            return await _dbContext.Representatives.ToListAsync();
        }

        public async Task<Representative> GetRepresentativeByIdAsync(int id)
        {
            return await _dbContext.Representatives
                .Include(r => r.Provider)
                .SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task CreateRepresentative(Representative representative)
        {
            await _dbContext.Representatives.AddAsync(representative);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
