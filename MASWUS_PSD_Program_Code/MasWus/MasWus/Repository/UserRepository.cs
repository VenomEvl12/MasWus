using MasWus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Repository
{
    public class UserRepository
    {
        public static void InsertUser(UserModel user) {
            using (MasWusEntities db = new MasWusEntities())
            {
                User userM = new User();
                userM.AccountName = user.Name;
                userM.Username = user.Username;
                userM.Password = user.Password;
                userM.RoleId = user.RoleId;

                db.Users.Add(userM);
                db.SaveChanges();
            }
        }

        public static bool SelectUser(string username)
        {
            using (MasWusEntities db = new MasWusEntities())
            {
                var query = from x in db.Users where x.Username == username select x;
                User user = (query).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }
                return true;
            }
        }

        public static User GetUserData(string username, string password)
        {
            MasWusEntities db = new MasWusEntities();
            db.Configuration.ProxyCreationEnabled = false;
            var query = from x in db.Users where x.Username == username && x.Password == password select x;
            User user = (query).FirstOrDefault();
            return user;
        }

    }
}