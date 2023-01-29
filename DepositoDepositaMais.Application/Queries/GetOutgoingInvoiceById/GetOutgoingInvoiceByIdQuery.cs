using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetOutgoingInvoiceById
{
    public class GetOutgoingInvoiceByIdQuery : IRequest<OutgoingInvoiceDetailsViewModel>
    {
        public GetOutgoingInvoiceByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
