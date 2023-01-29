using DepositoDepositaMais.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllOutgoingOrders
{
    public class GetAllOutgoingOrdersQuery : IRequest<List<OutgoingOrderViewModel>>
    {
        public GetAllOutgoingOrdersQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
