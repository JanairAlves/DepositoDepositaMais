using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateCategoryCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(
                request.CategoryName,
                request.Description
                );

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category.Id;
        }
    }
}
