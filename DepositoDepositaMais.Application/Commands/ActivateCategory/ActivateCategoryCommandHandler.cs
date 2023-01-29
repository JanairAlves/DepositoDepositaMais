using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateCategory
{
    public class ActivateCategoryCommandHandler : IRequestHandler<ActivateCategoryCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateCategoryCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == request.Id);
            category.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
