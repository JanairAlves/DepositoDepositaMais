using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetStorageLocationById
{
    public class GetStorageLocationByIdQuery : IRequest<StorageLocationDetailsViewModel>
    {
        public GetStorageLocationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
