namespace Catalog.Security.Identity
{
    public class Order
    {
        public int OrderId { get; set; }
        public int FoodDeliverySystemId { get; set; }
        public int ClientId { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
    }
}
