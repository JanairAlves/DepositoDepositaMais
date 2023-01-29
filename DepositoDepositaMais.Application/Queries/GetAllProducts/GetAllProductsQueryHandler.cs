using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllProductsQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var product = _dbContext.Products;

            var productViewModel = await product
                .Select(p => new ProductViewModel(
                    p.ProductCode,
                    p.ProviderId,
                    p.ProductName,
                    p.PackagingType,
                    p.QuantityPackaging)
                    ).ToListAsync();

            return productViewModel;
        }
    }
}
