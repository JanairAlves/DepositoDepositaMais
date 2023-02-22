using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Repositories
{
    public class IncomingOrderRepository : IIncomingOrderRepository
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public IncomingOrderRepository(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IncomingOrder>> GetAllIncomingOrdersAsync()
        {
            return await _dbContext.IncomingOrders.ToListAsync();
        }

        public async Task<IncomingOrder> GetIncomingOrderByIdAsync(int id)
        {
            return await _dbContext.IncomingOrders
                .Include(io => io.Deposit)
                .Include(io => io.Representative)
                .SingleOrDefaultAsync(io => io.Id == id);
        }

        public async Task CreateIncomingOrder(IncomingOrder incomingOrder)
        {
            await _dbContext.IncomingOrders.AddAsync(incomingOrder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsyn()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
