using DepositoDepositaMais.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductViewModel>>
    {
        public GetAllProductsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
