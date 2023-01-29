using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllOutgoingInvoices
{
    public class GetAllOutgoingInvoicesQueryHandler : IRequestHandler<GetAllOutgoingInvoicesQuery, List<OutgoingInvoiceViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllOutgoingInvoicesQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OutgoingInvoiceViewModel>> Handle(GetAllOutgoingInvoicesQuery request, CancellationToken cancellationToken)
        {
            var outgoingInvoice = _dbContext.OutgoingInvoices;

            var outgoingInvoiceViewModel = await outgoingInvoice
                .Select(oi => new OutgoingInvoiceViewModel(
                    oi.Id,
                oi.DepositId,
                oi.StorageLocationId,
                oi.ProductId,
                oi.Quantity,
                oi.Value)
                ).ToListAsync();

            return outgoingInvoiceViewModel;
        }
    }
}
