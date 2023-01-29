using DepositoDepositaMais.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Queries.GetAllProviders
{
    public class GetAllProvidersQuery : IRequest<List<ProviderViewModel>>
    {
        public GetAllProvidersQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
