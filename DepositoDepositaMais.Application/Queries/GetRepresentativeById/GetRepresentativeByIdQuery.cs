using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetRepresentativeById
{
    public class GetRepresentativeByIdQuery : IRequest<RepresentativeDetailsViewModel>
    {
        public GetRepresentativeByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
