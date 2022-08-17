using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public ProductService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewProduct(NewProductInputModel inputModel)
        {
            var product = new Product(
                inputModel.ProductId,
                inputModel.ProviderId,
                inputModel.ProductName,
                inputModel.Description,
                inputModel.PackagingType,
                inputModel.QuantityPackaging
                );
            _dbContext.Products.Add(product);

            return product.Id;
        }

        public void UpdateProduct(UpdateProductInputModel inputModel)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == inputModel.Id);
            product.Update(
                product.ProductId,
                product.ProviderId,
                product.ProductName,
                product.Description,
                product.PackagingType,
                product.QuantityPackaging
                );
        }

        public List<ProductViewModel> GetAll(string query)
        {
            var product = _dbContext.Products;
            var productViewModel = product
                .Select(p => new ProductViewModel(
                    p.ProductId,
                    p.ProviderId,
                    p.ProductName,
                    p.PackagingType,
                    p.QuantityPackaging)
                    ).ToList();

            return productViewModel;
        }

        public ProductDetailsViewModel GetById(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            var productDetailsViewModel = new ProductDetailsViewModel(
                product.ProductId,
                product.ProviderId,
                product.ProductName,
                product.Description,
                product.PackagingType,
                product.QuantityPackaging,
                product.Status,
                product.CreatedAt
               );

            return productDetailsViewModel;
        }

        public void ActivateProduct(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            product.Activate();
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            product.Inactivate();
        }
    }
}
