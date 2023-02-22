using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.ProductCode,
                request.ProviderId,
                request.ProductName,
                request.Description,
                request.PackagingType,
                request.QuantityPackaging
                );

            await _productRepository.CreateProduct(product);

            return product.Id;
        }
    }
}
