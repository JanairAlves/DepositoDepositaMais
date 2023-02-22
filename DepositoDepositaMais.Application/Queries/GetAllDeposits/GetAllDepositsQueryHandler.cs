using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllDeposits
{
    public class GetAllDepositsQueryHandler : IRequestHandler<GetAllDepositsQuery, List<DepositViewModel>>
    {
        private readonly IDepositRepository depositRepository;
        public GetAllDepositsQueryHandler(IDepositRepository depositRepository)
        {
            this.depositRepository = depositRepository;
        }

        public async Task<List<DepositViewModel>> Handle(GetAllDepositsQuery request, CancellationToken cancellationToken)
        {
            var deposits = await depositRepository.GetAllDepositsAsync();

            var depositsViewModel = deposits
                .Select(d => new DepositViewModel(d.Id, d.DepositName)
                ).ToList();

            return depositsViewModel;
        }
    }
}
