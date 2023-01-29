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

namespace DepositoDepositaMais.Application.Queries.GetAllOutgoingOrders
{
    public class GetAllOutgoingOrdersQueryHandler : IRequestHandler<GetAllOutgoingOrdersQuery, List<OutgoingOrderViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllOutgoingOrdersQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OutgoingOrderViewModel>> Handle(GetAllOutgoingOrdersQuery request, CancellationToken cancellationToken)
        {
            var outgoingOrder = _dbContext.OutgoingOrders;

            var outgoingOrderViewModel = await outgoingOrder
                .Select(oo => new OutgoingOrderViewModel(
                    oo.Id,
                    oo.DepositId,
                    oo.StorageLocationId,
                    oo.ProductId,
                    oo.Quantity,
                    oo.Value)
                ).ToListAsync();

            return outgoingOrderViewModel;
        }
    }
}
