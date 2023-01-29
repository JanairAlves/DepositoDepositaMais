using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateStorageLocation
{
    public class ActivateStorageLocationCommandHandler : IRequestHandler<ActivateStorageLocationCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateStorageLocationCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateStorageLocationCommand request, CancellationToken cancellationToken)
        {
            var storageLocation = _dbContext.StorageLocations.SingleOrDefault(sl => sl.Id == request.Id);

            storageLocation.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
