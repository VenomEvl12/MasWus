using MasWus.Model;
using MasWus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Handler
{
    public class UserHandler
    {
        public static void InsertModel(UserModel user)
        {
            UserRepository.InsertUser(user);
        }

        public static bool SelectUsername(string username)
        {
            return UserRepository.SelectUser(username);
        }

        public static User GetUserData(string username, string password)
        {
            return UserRepository.GetUserData(username, password);
        }
    }
}