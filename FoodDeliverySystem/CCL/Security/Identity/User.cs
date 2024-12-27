namespace Catalog.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, int FoodDeliverySystemId)
        {
            UserId = userId;
            Name = name;
            FoodDeliverySystemID = FoodDeliverySystemId;
        }

        public int UserId { get; }
        public string Name { get; }
        public int FoodDeliverySystemID { get; }
    }
}
