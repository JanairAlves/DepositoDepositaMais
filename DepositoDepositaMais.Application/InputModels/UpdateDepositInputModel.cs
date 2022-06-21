
namespace DepositoDepositaMais.Application.InputModels
{
    public class UpdateDepositInputModel
    {
        public int Id { get; }
        public string DepositName { get; private set; }
        public string Description { get; private set; }
        public string CNPJ { get; private set; }
    }
}
