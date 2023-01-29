using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateUserCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                request.FullName,
                request.Email,
                request.BirthDate
                );

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
