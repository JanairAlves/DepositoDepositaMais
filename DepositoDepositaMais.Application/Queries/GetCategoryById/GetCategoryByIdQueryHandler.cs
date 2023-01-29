using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetCategoryByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryDetailsViewModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == request.Id);

            if (category == null) 
                return null;

            var categoryDetailsViewModel = new CategoryDetailsViewModel(
                category.Id,
                category.CategoryName,
                category.Description,
                category.Status,
                category.CreatedAt
                );

            return categoryDetailsViewModel;
        }
    }
}
