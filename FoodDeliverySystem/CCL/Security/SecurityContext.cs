﻿using Catalog.Security.Identity;

namespace Catalog.CCL.Security
{
    public static class SecurityContext
    {
        static User _user = null;

        public static User GetUser()
        {
            return _user;
        }

        public static void SetUser(User user)
        {
            _user = user;
        }
    }
}
