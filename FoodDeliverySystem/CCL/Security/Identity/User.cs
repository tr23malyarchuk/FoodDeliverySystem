namespace Catalog.Security.Identity
{
    public class Client : User
    {
        public Client(int userId, string name, int foodDeliverySystemId)
            : base(userId, name, foodDeliverySystemId)
        {
        }
    }
}
