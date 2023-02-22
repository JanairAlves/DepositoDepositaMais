using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllOutgoingOrders
{
    public class GetAllOutgoingOrdersQueryHandler : IRequestHandler<GetAllOutgoingOrdersQuery, List<OutgoingOrderViewModel>>
    {
        private readonly IOutgoingOrderRepository _outgoingOrderRepository;
        public GetAllOutgoingOrdersQueryHandler(IOutgoingOrderRepository outgoingOrderRepository)
        {
            _outgoingOrderRepository = outgoingOrderRepository;
        }

        public async Task<List<OutgoingOrderViewModel>> Handle(GetAllOutgoingOrdersQuery request, CancellationToken cancellationToken)
        {
            var outgoingOrders = await _outgoingOrderRepository.GetAllOutgoingOrdersAsync();

            var outgoingOrdersViewModel = outgoingOrders
                .Select(oo => new OutgoingOrderViewModel(
                    oo.Id,
                    oo.DepositId,
                    oo.StorageLocationId,
                    oo.ProductId,
                    oo.Quantity,
                    oo.Value)
                ).ToList();

            return outgoingOrdersViewModel;
        }
    }
}
