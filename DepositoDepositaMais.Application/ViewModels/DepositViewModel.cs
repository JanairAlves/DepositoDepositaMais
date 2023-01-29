namespace DepositoDepositaMais.Application.ViewModels
{
    public class DepositViewModel
    {
        public DepositViewModel(int id, string depositName)
        {
            Id = id;
            DepositName = depositName;
        }

        public int Id { get; }
        public string DepositName { get; private set; }
    }
}
