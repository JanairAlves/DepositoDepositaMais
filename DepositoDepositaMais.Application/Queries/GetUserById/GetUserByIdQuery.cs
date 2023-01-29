using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDetailsViewModel>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
