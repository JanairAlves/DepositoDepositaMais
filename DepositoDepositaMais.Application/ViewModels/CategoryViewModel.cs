
namespace DepositoDepositaMais.Application.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }

        public int Id { get; }
        public string CategoryName { get; private set; }
    }
}
