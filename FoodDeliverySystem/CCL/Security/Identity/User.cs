namespace Catalog.Security.Identity
{
    public class User : Client
    {
        public User(int clientId, string name, int foodDeliverySystemId)
            : base(clientId, name, foodDeliverySystemId)
        {
        }
    }
}
