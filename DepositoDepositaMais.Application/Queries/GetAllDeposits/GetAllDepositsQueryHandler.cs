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

namespace DepositoDepositaMais.Application.Queries.GetAllDeposits
{
    public class GetAllDepositsQueryHandler : IRequestHandler<GetAllDepositsQuery, List<DepositViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllDepositsQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DepositViewModel>> Handle(GetAllDepositsQuery request, CancellationToken cancellationToken)
        {
            var deposits = _dbContext.Deposits;

            var depositsViewModel = await deposits
                .Select(d => new DepositViewModel(d.Id, d.DepositName)
                ).ToListAsync();

            return depositsViewModel;
        }
    }
}
