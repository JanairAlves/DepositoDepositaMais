using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateProvider
{
    public class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateProviderCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = _dbContext.Providers.SingleOrDefault(p => p.Id == request.Id);

            provider.Update(
                request.providerName,
                request.Description,
                request.CNPJ,
                request.Site,
                request.EmailAddress,
                request.PhoneNumber,
                request.ProviderType
                );

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
