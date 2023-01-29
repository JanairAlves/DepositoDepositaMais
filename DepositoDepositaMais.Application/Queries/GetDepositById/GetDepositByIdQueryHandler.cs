using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetDepositById
{
    public class GetDepositByIdQueryHandler : IRequestHandler<GetDepositByIdQuery, DepositDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetDepositByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DepositDetailsViewModel> Handle(GetDepositByIdQuery request, CancellationToken cancellationToken)
        {
            var deposit = await _dbContext.Deposits.SingleOrDefaultAsync(d => d.Id == request.Id);

            var depositsDetailsViewModel = new DepositDetailsViewModel(
                deposit.Id,
                deposit.DepositName,
                deposit.Description,
                deposit.CNPJ,
                deposit.Status,
                deposit.CreatedAt
                );

            return depositsDetailsViewModel;
        }
    }
}
