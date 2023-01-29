using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateProduct
{
    public class ActivateProductCommandHandler : IRequestHandler<ActivateProductCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateProductCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == request.Id);

            product.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
