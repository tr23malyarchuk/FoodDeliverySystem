namespace Catalog.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Status { get; set; }

    }
}
