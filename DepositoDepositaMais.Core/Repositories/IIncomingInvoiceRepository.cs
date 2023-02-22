using DepositoDepositaMais.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Repositories
{
    public interface IIncomingInvoiceRepository
    {
        Task<List<IncomingInvoice>> GetAllIncomingInvoicesAsync();
        Task<IncomingInvoice> GetIncomingInvoiceByIdAsync(int id);
        Task CreateIncomingInvoice(IncomingInvoice incomingInvoice);
        Task SaveChangesAsync();
    }
}
