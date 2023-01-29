using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetUserByIdQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(u => u.Deposit)
                .SingleOrDefaultAsync(u => u.Id == request.Id);

            var userDetailsViewModel = new UserDetailsViewModel(
                user.FullName,
                user.Email,
                user.BirthDate,
                user.UserSkills,
                user.Status,
                user.CreatedAt,
                user.Deposit.DepositName
                );

            return userDetailsViewModel;
        }
    }
}
