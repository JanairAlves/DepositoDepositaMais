using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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
                inputModel.ProductCode,
                inputModel.ProviderId,
                inputModel.ProductName,
                inputModel.Description,
                inputModel.PackagingType,
                inputModel.QuantityPackaging
                );

            _dbContext.Products.Add(product);

            _dbContext.SaveChanges();

            return product.Id;
        }

        public void UpdateProduct(UpdateProductInputModel inputModel)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == inputModel.Id);

            product.Update(
                product.ProductCode,
                product.ProviderId,
                product.ProductName,
                product.Description,
                product.PackagingType,
                product.QuantityPackaging
                );

            _dbContext.SaveChanges();
        }

        public List<ProductViewModel> GetAll(string query)
        {
            var product = _dbContext.Products;

            var productViewModel = product
                .Select(p => new ProductViewModel(
                    p.ProductCode,
                    p.ProviderId,
                    p.ProductName,
                    p.PackagingType,
                    p.QuantityPackaging)
                    ).ToList();

            return productViewModel;
        }

        public ProductDetailsViewModel GetById(int id)
        {
            var product = _dbContext.Products
                .Include(p => p.StorageLocation)
                .Include(p => p.Category)
                .SingleOrDefault(p => p.Id == id);

            var productDetailsViewModel = new ProductDetailsViewModel(
                product.ProductCode,
                product.ProviderId,
                product.ProductName,
                product.Description,
                product.PackagingType,
                product.QuantityPackaging,
                product.Status,
                product.CreatedAt,
                product.StorageLocation.Id,
                product.StorageLocation.Street,
                product.Category.CategoryName
               );

            return productDetailsViewModel;
        }

        public void ActivateProduct(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            product.Activate();

            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            product.Inactivate();

            _dbContext.SaveChanges();
        }
    }
}
