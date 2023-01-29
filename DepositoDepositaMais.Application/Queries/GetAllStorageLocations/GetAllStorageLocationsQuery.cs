using DepositoDepositaMais.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DepositoDepositaMais.Application.Queries.GetAllStorageLocations
{
    public class GetAllStorageLocationsQuery : IRequest<List<StorageLocationViewModel>>
    {
        public GetAllStorageLocationsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
