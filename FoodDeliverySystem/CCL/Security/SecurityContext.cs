using Catalog.Security.Identity;

namespace Catalog.CCL.Security
{
    public static class SecurityContext
    {
        static Client _user = null;

        public static Client GetUser()
        {
            return _user;
        }

        public static void SetUser(Client user)
        {
            _user = user;
        }
    }
}
