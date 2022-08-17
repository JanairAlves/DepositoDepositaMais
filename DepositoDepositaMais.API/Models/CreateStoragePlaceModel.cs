namespace DepositoDepositaMais.API.Models
{
    public class CreateStoragePlaceModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
