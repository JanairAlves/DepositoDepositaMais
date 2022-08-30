namespace DepositoDepositaMais.API.Models
{
    public class CreateStorageLocationModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
