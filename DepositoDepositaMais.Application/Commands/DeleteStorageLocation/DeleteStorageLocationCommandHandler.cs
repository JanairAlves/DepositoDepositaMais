using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteStorageLocation
{
    public class DeleteStorageLocationCommandHandler : IRequestHandler<DeleteStorageLocationCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public DeleteStorageLocationCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteStorageLocationCommand request, CancellationToken cancellationToken)
        {
            var storageLocation = _dbContext.StorageLocations.SingleOrDefault(sl => sl.Id == request.Id);

            storageLocation.Inactivate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
