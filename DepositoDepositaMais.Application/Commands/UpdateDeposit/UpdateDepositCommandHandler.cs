using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateDeposit
{
    public class UpdateDepositCommandHandler : IRequestHandler<UpdateDepositCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateDepositCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateDepositCommand request, CancellationToken cancellationToken)
        {
            var deposit = _dbContext.Deposits.SingleOrDefault(d => d.Id == request.Id);

            deposit.Update(request.DepositName, request.Description, request.CNPJ);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
