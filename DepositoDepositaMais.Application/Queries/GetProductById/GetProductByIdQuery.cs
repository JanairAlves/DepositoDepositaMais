using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDetailsViewModel>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
