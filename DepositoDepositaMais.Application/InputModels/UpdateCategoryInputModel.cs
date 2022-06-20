using DepositoDepositaMais.Core.Enums;

namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateCategoryInputModel
    {
        public int Id { get; }
        public string CategoryName { get; private set; }
        public string Description { get; private set; }
    }
}
