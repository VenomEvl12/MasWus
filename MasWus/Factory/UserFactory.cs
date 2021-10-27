using MasWus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Factory
{
    public static class UserFactory
    {
        public static User createUser(string name, string username, string password)
        {
            User user = new User();
            user.AccountName = name;
            user.Username = username;
            user.Password = password;
            user.RoleId = 2;
            return user;
        }
    }
}