using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteDeposit
{
    public class DeleteDepositCommandHandler : IRequestHandler<DeleteDepositCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public DeleteDepositCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteDepositCommand request, CancellationToken cancellationToken)
        {
            var deposit = _dbContext.Deposits.SingleOrDefault(d => d.Id == request.Id);
            
            deposit.Inactivate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
