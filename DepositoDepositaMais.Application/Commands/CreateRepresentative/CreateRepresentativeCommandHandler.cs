using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.CreateRepresentative
{
    public class CreateRepresentativeCommandHandler : IRequestHandler<CreateRepresentativeCommand, int>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public CreateRepresentativeCommandHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateRepresentativeCommand request, CancellationToken cancellationToken)
        {
            var representative = new Representative(
                request.ProviderId,
                request.RepresentativeName,
                request.Birthday,
                request.CPF,
                request.PhoneNumber,
                request.Email,
                request.Description
                );

            await _dbContext.Representatives.AddAsync(representative);
            await _dbContext.SaveChangesAsync();

            return representative.Id;
        }
    }
}
