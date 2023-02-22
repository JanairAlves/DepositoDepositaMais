using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetDepositById
{
    public class GetDepositByIdQueryHandler : IRequestHandler<GetDepositByIdQuery, DepositDetailsViewModel>
    {
        private readonly IDepositRepository _depositRepository;
        public GetDepositByIdQueryHandler(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        public async Task<DepositDetailsViewModel> Handle(GetDepositByIdQuery request, CancellationToken cancellationToken)
        {
            var deposit = await _depositRepository.GetDepositByIdAsync(request.Id);

            var depositDetailsViewModel = new DepositDetailsViewModel(
                deposit.Id,
                deposit.DepositName,
                deposit.Description,
                deposit.CNPJ,
                deposit.Status,
                deposit.CreatedAt
                );

            return depositDetailsViewModel;
        }
    }
}
