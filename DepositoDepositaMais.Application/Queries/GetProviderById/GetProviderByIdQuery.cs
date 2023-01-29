using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetProviderById
{
    public class GetProviderByIdQuery : IRequest<ProviderDetailsViewModel>
    {
        public GetProviderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
