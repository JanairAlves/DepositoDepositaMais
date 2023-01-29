using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.UpdateRepresentative
{
    public class UpdateRepresentativeCommandHandler : IRequestHandler<UpdateRepresentativeCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public UpdateRepresentativeCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var representative = _dbContext.Representatives.SingleOrDefault(r => r.Id == request.Id);

            representative.Update(
                request.ProviderId,
                request.RepresentativeName,
                request.Birthday,
                request.CPF,
                request.PhoneNumber,
                request.Email,
                request.Description
                );

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
