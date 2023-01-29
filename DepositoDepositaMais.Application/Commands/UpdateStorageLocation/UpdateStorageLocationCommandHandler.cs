using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateStorageLocation
{
    public class UpdateStorageLocationCommandHandler : IRequestHandler<UpdateStorageLocationCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateStorageLocationCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateStorageLocationCommand request, CancellationToken cancellationToken)
        {
            var storageLocation = _dbContext.StorageLocations.FirstOrDefault(s => s.Id == request.Id);

            storageLocation.Update(
                request.Quantity,
                request.MinimumQuantity,
                request.MaximumQuantity,
                request.Street
                );

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
