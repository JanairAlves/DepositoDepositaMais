using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.DeleteRepresentative
{
    public class DeleteRepresentativeCommandHandler : IRequestHandler<DeleteRepresentativeCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public DeleteRepresentativeCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var representative = _dbContext.Representatives.SingleOrDefault(r => r.Id == request.Id);

            representative.Inactivate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
