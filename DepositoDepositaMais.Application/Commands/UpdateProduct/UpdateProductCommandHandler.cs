using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateProductCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == request.Id);

            product.Update(
                request.ProductCode,
                request.ProviderId,
                request.ProductName,
                request.Description,
                request.PackagingType,
                request.QuantityPackaging
                );

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
