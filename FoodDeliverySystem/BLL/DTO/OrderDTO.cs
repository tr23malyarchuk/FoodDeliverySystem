namespace Catalog.BLL.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int FoodDeliverySystemId { get; set; }
        public int ClientId { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
    }
}
