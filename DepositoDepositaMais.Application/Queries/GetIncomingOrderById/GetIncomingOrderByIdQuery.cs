using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetIncomingOrderById
{
    public class GetIncomingOrderByIdQuery : IRequest<IncomingOrderDetailsViewModel>
    {
        public GetIncomingOrderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
