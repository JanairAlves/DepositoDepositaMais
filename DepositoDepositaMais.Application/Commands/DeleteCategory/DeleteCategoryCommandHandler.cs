using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public DeleteCategoryCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == request.Id);

            category.Inactivate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
