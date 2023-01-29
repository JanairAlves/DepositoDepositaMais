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

namespace DepositoDepositaMais.Application.Commands.ActivateDeposit
{
    public class ActivateDepositCommandHandler : IRequestHandler<ActivateDepositCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateDepositCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateDepositCommand request, CancellationToken cancellationToken)
        {
            var deposit = _dbContext.Deposits.SingleOrDefault(d => d.Id == request.Id);
            
            deposit.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
