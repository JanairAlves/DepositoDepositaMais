using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateStorageLocation
{
    public class UpdateStorageLocationCommandHandler : IRequestHandler<UpdateStorageLocationCommand, Unit>
    {
        private readonly IStorageLocationRepository _storageLocationRepository;
        public UpdateStorageLocationCommandHandler(IStorageLocationRepository storageLocationRepository)
        {
            _storageLocationRepository = storageLocationRepository;
        }

        public async Task<Unit> Handle(UpdateStorageLocationCommand request, CancellationToken cancellationToken)
        {
            var storageLocation = await _storageLocationRepository.GetStorageLocationByIdAsync(request.Id);

            storageLocation.Update(
                request.Quantity,
                request.MinimumQuantity,
                request.MaximumQuantity,
                request.Street
                );

            await _storageLocationRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
