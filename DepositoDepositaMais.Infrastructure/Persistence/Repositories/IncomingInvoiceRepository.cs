using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Repositories
{
    public class IncomingInvoiceRepository : IIncomingInvoiceRepository
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public IncomingInvoiceRepository(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IncomingInvoice>> GetAllIncomingInvoicesAsync()
        {
            return await _dbContext.IncomingInvoices.ToListAsync();
        }

        public async Task<IncomingInvoice> GetIncomingInvoiceByIdAsync(int id)
        {
            return await _dbContext.IncomingInvoices.SingleOrDefaultAsync(ii => ii.Id == id);
        }

        public async Task CreateIncomingInvoice(IncomingInvoice incomingInvoice)
        {
            await _dbContext.IncomingInvoices.AddAsync(incomingInvoice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
