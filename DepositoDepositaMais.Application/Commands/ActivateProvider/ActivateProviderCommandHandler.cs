using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateProvider
{
    public class ActivateProviderCommandHandler : IRequestHandler<ActivateProviderCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateProviderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = _dbContext.Providers.SingleOrDefault(p => p.Id == request.Id);

            provider.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
