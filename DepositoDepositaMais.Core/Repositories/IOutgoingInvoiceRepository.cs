using DepositoDepositaMais.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Repositories
{
    public interface IOutgoingInvoiceRepository
    {
        Task<List<OutgoingInvoice>> GetAllOutgoingInvoicesAsync();
        Task<OutgoingInvoice> GetOutgoingInvoiceByIdAsync(int id);
        Task CreateOutgoingInvoice(OutgoingInvoice outgoingInvoice);
        Task SaveChangesAsync();
    }
}
