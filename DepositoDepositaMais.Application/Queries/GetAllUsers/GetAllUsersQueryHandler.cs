using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public GetAllUsersQueryHandler(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users;

            var userViewModel = await user
                .Select(u => new UserViewModel(
                    u.FullName,
                    u.Email,
                    u.BirthDate,
                    u.Status)
                ).ToListAsync();

            return userViewModel;
        }
    }
}
