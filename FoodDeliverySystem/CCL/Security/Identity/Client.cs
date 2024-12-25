namespace Catalog.Security.Identity
{
    public abstract class Client
    {
        public Client(int clientId, string name, int FoodDeliverySystemId)
        {
            ClientId = clientId;
            Name = name;
            FoodDeliverySystemID = FoodDeliverySystemId;
        }

        public int ClientId { get; }
        public string Name { get; }
        public int FoodDeliverySystemID { get; }
    }
}
