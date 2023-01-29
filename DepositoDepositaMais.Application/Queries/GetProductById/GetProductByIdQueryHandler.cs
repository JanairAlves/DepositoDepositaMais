using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetProductByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDetailsViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .Include(p => p.StorageLocation)
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

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
    }
}
