using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetOutgoingOrderById
{
    public class GetOutgoingOrderByIdQuery : IRequest<OutgoingOrderDetailsViewModel>
    {
        public GetOutgoingOrderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
