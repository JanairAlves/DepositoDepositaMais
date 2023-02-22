using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateStorageLocation
{
    public class ActivateStorageLocationCommandHandler : IRequestHandler<ActivateStorageLocationCommand, Unit>
    {
        private readonly IStorageLocationRepository _storageLocationRepository;
        public ActivateStorageLocationCommandHandler(IStorageLocationRepository storageLocationRepository)
        {
            _storageLocationRepository = storageLocationRepository;
        }

        public async Task<Unit> Handle(ActivateStorageLocationCommand request, CancellationToken cancellationToken)
        {
            var storageLocation = await _storageLocationRepository.GetStorageLocationByIdAsync(request.Id);

            storageLocation.Activate();

            await _storageLocationRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
