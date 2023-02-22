using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllStorageLocations
{
    public class GetAllStorageLocationsQueryHandler : IRequestHandler<GetAllStorageLocationsQuery, List<StorageLocationViewModel>>
    {
        private readonly IStorageLocationRepository _storageLocationRepository;
        public GetAllStorageLocationsQueryHandler(IStorageLocationRepository storageLocationRepository)
        {
            _storageLocationRepository = storageLocationRepository;
        }

        public async Task<List<StorageLocationViewModel>> Handle(GetAllStorageLocationsQuery request, CancellationToken cancellationToken)
        {
            var storageLocations = await _storageLocationRepository.GetAllStorageLocationsAsync();

            var storageLocationsViewModel = storageLocations
                .Select(s => new StorageLocationViewModel(
                    s.Id,
                    s.ProductId,
                    s.Quantity,
                    s.Street)
                ).ToList();

            return storageLocationsViewModel;
        }
    }
}
