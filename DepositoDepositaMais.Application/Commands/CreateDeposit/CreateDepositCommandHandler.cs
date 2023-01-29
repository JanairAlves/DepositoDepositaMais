using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateDeposit
{
    public class CreateDepositCommandHandler : IRequestHandler<CreateDepositCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateDepositCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateDepositCommand request, CancellationToken cancellationToken)
        {
            var deposit = new Deposit(
                request.DepositName,
                request.Description,
                request.CNPJ
                );

            await _dbContext.Deposits.AddAsync(deposit);
            await _dbContext.SaveChangesAsync();

            return deposit.Id;
        }
    }
}
