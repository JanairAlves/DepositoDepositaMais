using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetDepositById
{
    public class GetDepositByIdQuery : IRequest<DepositDetailsViewModel>
    {
        public GetDepositByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
