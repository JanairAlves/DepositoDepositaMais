using DepositoDepositaMais.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public GetAllUsersQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
