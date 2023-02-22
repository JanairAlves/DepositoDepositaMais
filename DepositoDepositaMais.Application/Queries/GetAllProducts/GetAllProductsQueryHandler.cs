using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsAsync();

            var productsViewModel = products
                .Select(p => new ProductViewModel(
                    p.ProductCode,
                    p.ProviderId,
                    p.ProductName,
                    p.PackagingType,
                    p.QuantityPackaging)
                    ).ToList();

            return productsViewModel;
        }
    }
}
