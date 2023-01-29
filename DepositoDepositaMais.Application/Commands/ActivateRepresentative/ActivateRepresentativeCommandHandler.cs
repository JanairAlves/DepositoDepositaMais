using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateRepresentative
{
    public class ActivateRepresentativeCommandHandler : IRequestHandler<ActivateRepresentativeCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateRepresentativeCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var representative = _dbContext.Representatives.SingleOrDefault(r => r.Id == request.Id);

            representative.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
