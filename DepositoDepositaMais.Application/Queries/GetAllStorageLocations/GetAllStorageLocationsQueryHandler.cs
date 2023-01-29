using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllStorageLocations
{
    public class GetAllStorageLocationsQueryHandler : IRequestHandler<GetAllStorageLocationsQuery, List<StorageLocationViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllStorageLocationsQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StorageLocationViewModel>> Handle(GetAllStorageLocationsQuery request, CancellationToken cancellationToken)
        {
            var storageLocation = _dbContext.StorageLocations;

            var storageLocationViewModel = await storageLocation
                .Select(s => new StorageLocationViewModel(
                    s.Id,
                    s.ProductId,
                    s.Quantity,
                    s.Street)
                ).ToListAsync();

            return storageLocationViewModel;
        }
    }
}
