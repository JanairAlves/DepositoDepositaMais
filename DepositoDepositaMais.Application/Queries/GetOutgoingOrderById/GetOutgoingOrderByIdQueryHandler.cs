using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetOutgoingOrderById
{
    public class GetOutgoingOrderByIdQueryHandler : IRequestHandler<GetOutgoingOrderByIdQuery, OutgoingOrderDetailsViewModel>
    {
        private readonly IOutgoingOrderRepository _outgoingOrderRepository;
        public GetOutgoingOrderByIdQueryHandler(IOutgoingOrderRepository outgoingOrderRepository)
        {
            _outgoingOrderRepository = outgoingOrderRepository;
        }

        public async Task<OutgoingOrderDetailsViewModel> Handle(GetOutgoingOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var outgoingOrder = await _outgoingOrderRepository.GetOutgoingOrderByIdAsync(request.Id);

            var outgoingOrderDetailsViewModel = new OutgoingOrderDetailsViewModel(
                outgoingOrder.Id,
                outgoingOrder.DepositId,
                outgoingOrder.StorageLocationId,
                outgoingOrder.ProductId,
                outgoingOrder.Quantity,
                outgoingOrder.Value,
                outgoingOrder.Description,
                outgoingOrder.Status,
                outgoingOrder.CreatedAt,
                outgoingOrder.SendIn,
                outgoingOrder.Deposit.DepositName,
                outgoingOrder.Deposit.CNPJ,
                outgoingOrder.Representative.RepresentativeName,
                outgoingOrder.Representative.CPF,
                outgoingOrder.Representative.PhoneNumber,
                outgoingOrder.Representative.Email
                );

            return outgoingOrderDetailsViewModel;
        }
    }
}
