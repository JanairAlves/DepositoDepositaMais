using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public CategoryService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewCategory(NewCategoryInputModel inputModel)
        {
            var category = new Category(inputModel.CategoryName, inputModel.Description);
            _dbContext.Categories.Add(category);

            return category.Id;
        }

        public void UpdateCategory(UpdateCategoryInputModel inputModel)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == inputModel.Id);
            
            category.Update(inputModel.CategoryName, inputModel.Description);
        }

        public List<CategoryViewModel> GetAll(string query)
        {
            var categories = _dbContext.Categories;
            var categoriesViewModel = categories
                .Select(c => new CategoryViewModel(c.Id, c.CategoryName))
                .ToList();

            return categoriesViewModel;
        }
        
        public CategoryDetailsViewModel GetById(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == id);

            if(category == null) return null;

            var categoryDetailsViewModel = new CategoryDetailsViewModel(
                category.Id,
                category.CategoryName,
                category.Description,
                category.Status,
                category.CreatedAt
                );

            return categoryDetailsViewModel;
        }

        public void ActivateCategory(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == id);
            category.Activate();
        }

        public void DeleteCategory(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == id);
            category.Inactivate();
        }
    }
}
