using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllIncomingInvoices
{
    public class GetAllIncomingInvoicesQuery : IRequest<GetAllIncomingInvoicesQuery>
    {
        public GetAllIncomingInvoicesQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
