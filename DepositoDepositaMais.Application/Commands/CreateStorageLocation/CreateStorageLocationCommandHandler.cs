using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateStorageLocation
{
    public class CreateStorageLocationCommandHandler : IRequestHandler<CreateStorageLocationCommand, int>
    {
        private readonly IStorageLocationRepository _storageLocationRepository;
        public CreateStorageLocationCommandHandler(IStorageLocationRepository storageLocationRepository)
        {
            _storageLocationRepository = storageLocationRepository;
        }

        public async Task<int> Handle(CreateStorageLocationCommand request, CancellationToken cancellationToken)
        {
            var storageLocation = new StorageLocation(
                request.ProductId,
                request.Quantity,
                request.MinimumQuantity,
                request.MaximumQuantity,
                request.Street
                );

            await _storageLocationRepository.CreateStorageLocation(storageLocation);

            return storageLocation.Id;
        }
    }
}
