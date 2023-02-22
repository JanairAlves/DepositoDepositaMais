using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetIncomingOrderById
{
    public class GetIncomingOrderByIdQueryHandler : IRequestHandler<GetIncomingOrderByIdQuery, IncomingOrderDetailsViewModel>
    {
        private readonly IIncomingOrderRepository _incomingOrderRepository;
        public GetIncomingOrderByIdQueryHandler(IIncomingOrderRepository incomingOrderRepository)
        {
            _incomingOrderRepository = incomingOrderRepository;
        }
        
        public async Task<IncomingOrderDetailsViewModel> Handle(GetIncomingOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var incomingOrder = await _incomingOrderRepository.GetIncomingOrderByIdAsync(request.Id);

            var incomingOrderDetailsViewModel = new IncomingOrderDetailsViewModel(
                incomingOrder.Id,
                incomingOrder.DepositId,
                incomingOrder.RepresentativeId,
                incomingOrder.Quantity,
                incomingOrder.Value,
                incomingOrder.Description,
                incomingOrder.Status,
                incomingOrder.CreatedAt,
                incomingOrder.ExpectedDeliveryIn,
                incomingOrder.Deposit.DepositName,
                incomingOrder.Deposit.CNPJ,
                incomingOrder.Representative.RepresentativeName,
                incomingOrder.Representative.CPF,
                incomingOrder.Representative.PhoneNumber,
                incomingOrder.Representative.Email
                );

            return incomingOrderDetailsViewModel;
        }
    }
}
