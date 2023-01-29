using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateUser
{
    public class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, Unit>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public ActivateUserCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == request.Id);

            user.Activate();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
