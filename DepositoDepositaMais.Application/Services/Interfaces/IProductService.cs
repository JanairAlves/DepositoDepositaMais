using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.ViewModels;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAll(string query);
        ProductDetailsViewModel GetById(int id);
        int CreateNewProduct(NewProductInputModel inputModel);
        void UpdateProduct(UpdateProductInputModel inputModel);
        void ActivateProduct(int id);
        void DeleteProduct(int id);
    }
}
