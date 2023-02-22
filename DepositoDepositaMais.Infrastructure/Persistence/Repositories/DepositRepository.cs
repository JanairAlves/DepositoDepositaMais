using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public DepositRepository(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Deposit>> GetAllDepositsAsync()
        {
            return await _dbContext.Deposits.ToListAsync();
        }

        public async Task<Deposit> GetDepositByIdAsync(int id)
        {
            return await _dbContext.Deposits.SingleOrDefaultAsync( d => d.Id == id);
        }

        public async Task CreateDepositAsync(Deposit deposit)
        {
            await _dbContext.Deposits.AddAsync(deposit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
