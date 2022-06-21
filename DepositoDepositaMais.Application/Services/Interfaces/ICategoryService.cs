using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetAll(string query);
        CategoryDetailsViewModel GetById(int id);
        int CreateNewCategory(NewCategoryInputModel inputModel);
        void UpdateCategory(UpdateCategoryInputModel inputModel);
        void ActivateCategory(int id);
        void DeleteCategory(int id);
    }
}
