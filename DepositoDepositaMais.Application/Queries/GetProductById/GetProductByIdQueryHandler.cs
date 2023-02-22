using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailsViewModel>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDetailsViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);

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
