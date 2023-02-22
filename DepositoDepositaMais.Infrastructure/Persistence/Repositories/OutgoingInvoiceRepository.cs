using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Repositories
{
    public class OutgoingInvoiceRepository : IOutgoingInvoiceRepository
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public OutgoingInvoiceRepository(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OutgoingInvoice>> GetAllOutgoingInvoicesAsync()
        {
            return await _dbContext.OutgoingInvoices.ToListAsync();
        }

        public async Task<OutgoingInvoice> GetOutgoingInvoiceByIdAsync(int id)
        {
            return await _dbContext.OutgoingInvoices.SingleOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task CreateOutgoingInvoice(OutgoingInvoice outgoingInvoice)
        {
            await _dbContext.OutgoingInvoices.AddAsync(outgoingInvoice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
