using DepositoDepositaMais.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.Queries.GetAllIncomingInvoices
{
    public class GetAllIncomingInvoicesQuery : IRequest<List<IncomingInvoiceViewModel>>
    {
        public GetAllIncomingInvoicesQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
