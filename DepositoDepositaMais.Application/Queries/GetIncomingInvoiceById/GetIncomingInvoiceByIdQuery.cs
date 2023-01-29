using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetIncomingInvoiceById
{
    public class GetIncomingInvoiceByIdQuery : IRequest<IncomingInvoiceDetailsViewModel>
    {
        public GetIncomingInvoiceByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
