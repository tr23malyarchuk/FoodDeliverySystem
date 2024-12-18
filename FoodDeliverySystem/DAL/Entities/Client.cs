namespace Catalog.DAL.Entities
{
    public class Client : User
    {
        public string Address { get; set; }
        public string CreditCard { get; set; }

    }
}
