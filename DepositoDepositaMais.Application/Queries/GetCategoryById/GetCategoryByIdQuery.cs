using DepositoDepositaMais.Application.ViewModels;
using MediatR;

namespace DepositoDepositaMais.Application.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDetailsViewModel>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
