using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Repositories
{
    public class OutgoingOrderRepository : IOutgoingOrderRepository
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public OutgoingOrderRepository(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OutgoingOrder>> GetAllOutgoingOrdersAsync()
        {
            return await _dbContext.OutgoingOrders.ToListAsync();
        }

        public async Task<OutgoingOrder> GetOutgoingOrderByIdAsync(int id)
        {
            return await _dbContext.OutgoingOrders
                .Include(oo => oo.Deposit)
                .Include(oo => oo.Representative)
                .SingleOrDefaultAsync(oo => oo.Id == id);
        }

        public async Task CreateOutgoingOrder(OutgoingOrder outgoingOrder)
        {
            await _dbContext.OutgoingOrders.AddAsync(outgoingOrder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
