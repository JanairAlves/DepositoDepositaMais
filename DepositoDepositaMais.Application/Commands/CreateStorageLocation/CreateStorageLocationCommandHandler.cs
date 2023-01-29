using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateStorageLocation
{
    public class CreateStorageLocationCommandHandler : IRequestHandler<CreateStorageLocationCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateStorageLocationCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
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

            await _dbContext.StorageLocations.AddAsync(storageLocation);
            await _dbContext.SaveChangesAsync();

            return storageLocation.Id;
        }
    }
}
