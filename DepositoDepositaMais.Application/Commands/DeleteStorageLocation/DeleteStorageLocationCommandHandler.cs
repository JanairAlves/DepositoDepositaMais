using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteStorageLocation
{
    public class DeleteStorageLocationCommandHandler : IRequestHandler<DeleteStorageLocationCommand, Unit>
    {
        private readonly IStorageLocationRepository _storageLocationRepository;
        public DeleteStorageLocationCommandHandler(IStorageLocationRepository storageLocationRepository)
        {
            _storageLocationRepository = storageLocationRepository;
        }

        public async Task<Unit> Handle(DeleteStorageLocationCommand request, CancellationToken cancellationToken)
        {
            var storageLocation = await _storageLocationRepository.GetStorageLocationByIdAsync(request.Id);

            storageLocation.Inactivate();

            await _storageLocationRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
