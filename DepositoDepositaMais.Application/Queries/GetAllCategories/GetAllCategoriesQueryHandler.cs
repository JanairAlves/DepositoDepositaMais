using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryViewModel>>
    {
        private readonly ICategoryRepository CategoryRepository;
        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public async Task<List<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await CategoryRepository.GetAllCategoriesAsync();

            var categoriesViewModel = categories
                .Select(c => new CategoryViewModel(c.Id, c.CategoryName)
                ).ToList();

            return categoriesViewModel;
        }
    }
}
