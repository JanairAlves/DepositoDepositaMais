using DepositoDepositaMais.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Application.Commands.ActivateCategory
{
    public class ActivateCategoryCommandHandler : IRequestHandler<ActivateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        public ActivateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(ActivateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(request.Id);

            category.Activate();

            await _categoryRepository.SaveChangesAsync()/

            return Unit.Value;
        }
    }
}
