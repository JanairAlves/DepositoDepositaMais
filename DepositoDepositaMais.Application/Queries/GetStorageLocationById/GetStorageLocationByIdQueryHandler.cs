using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetStorageLocationById
{
    public class GetStorageLocationByIdQueryHandler : IRequestHandler<GetStorageLocationByIdQuery, StorageLocationDetailsViewModel>
    {
        private readonly IStorageLocationRepository _storageLocationRepository;
        public GetStorageLocationByIdQueryHandler(IStorageLocationRepository storageLocationRepository)
        {
            _storageLocationRepository = storageLocationRepository;
        }

        public async Task<StorageLocationDetailsViewModel> Handle(GetStorageLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var storageLocation = await _storageLocationRepository.GetStorageLocationByIdAsync(request.Id);

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
