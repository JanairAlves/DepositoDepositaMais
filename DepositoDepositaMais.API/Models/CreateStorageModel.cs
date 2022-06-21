namespace DepositoDepositaMais.API.Models
{
    public class CreateStorageModel
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
    }
}
