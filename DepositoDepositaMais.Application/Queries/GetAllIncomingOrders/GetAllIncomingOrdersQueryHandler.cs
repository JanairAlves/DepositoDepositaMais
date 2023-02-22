using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllIncomingOrders
{
    public class GetAllIncomingOrdersQueryHandler : IRequestHandler<GetAllIncomingOrdersQuery, List<IncomingOrderViewModel>>
    {
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        public GetAllIncomingOrdersQueryHandler(IIncomingOrderRepository incomingOrderRepository)
        {
            _incomingOrderRepository = incomingOrderRepository;
        }

        public async Task<List<IncomingOrderViewModel>> Handle(GetAllIncomingOrdersQuery request, CancellationToken cancellationToken)
        {
            var incomingOrders = await _incomingOrderRepository.GetAllIncomingOrdersAsync();

            var incomingOrdersViewModel = incomingOrders
                .Select(io => new IncomingOrderViewModel(
                    io.Id,
                    io.DepositId,
                    io.Quantity,
                    io.Value,
                    io.Status,
                    io.CreatedAt)
                ).ToList();

            return incomingOrdersViewModel;
        }
    }
}
