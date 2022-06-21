namespace DepositoDepositaMais.API.Models
{
    public class CreateProviderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
    }
}
