using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetStorageLocationById
{
    public class GetStorageLocationByIdQueryHandler : IRequestHandler<GetStorageLocationByIdQuery, StorageLocationDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetStorageLocationByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StorageLocationDetailsViewModel> Handle(GetStorageLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var storageLocation = await _dbContext.StorageLocations
                .Include(sl => sl.Deposit)
                .SingleOrDefaultAsync(s => s.Id == request.Id);

            var storageLocationViewModel = new StorageLocationDetailsViewModel(
                storageLocation.Id,
                storageLocation.ProductId,
                storageLocation.Quantity,
                storageLocation.MinimumQuantity,
                storageLocation.MaximumQuantity,
                storageLocation.Street,
                storageLocation.Deposit.DepositName
                );

            return storageLocationViewModel;
        }
    }
}
