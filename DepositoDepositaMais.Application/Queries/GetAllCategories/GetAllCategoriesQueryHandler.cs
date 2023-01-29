using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllCategoriesQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = _dbContext.Categories;

            var categoriesViewModel = await categories
                .Select(c => new CategoryViewModel(c.Id, c.CategoryName)
                ).ToListAsync();

            return categoriesViewModel;
        }
    }
}
