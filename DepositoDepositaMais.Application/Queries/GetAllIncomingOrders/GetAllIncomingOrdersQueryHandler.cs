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

namespace DepositoDepositaMais.Application.Queries.GetAllIncomingOrders
{
    public class GetAllIncomingOrdersQueryHandler : IRequestHandler<GetAllIncomingOrdersQuery, List<IncomingOrderViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllIncomingOrdersQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IncomingOrderViewModel>> Handle(GetAllIncomingOrdersQuery request, CancellationToken cancellationToken)
        {
            var incomingOrder = _dbContext.IncomingOrders;

            var incomingOrderViewModel = await incomingOrder
                .Select(io => new IncomingOrderViewModel(
                    io.Id,
                    io.DepositId,
                    io.Quantity,
                    io.Value,
                    io.Status,
                    io.CreatedAt)
                ).ToListAsync();

            return incomingOrderViewModel;
        }
    }
}
