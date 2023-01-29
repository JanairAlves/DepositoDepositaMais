using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateProductCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
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

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product.Id;
        }
    }
}
