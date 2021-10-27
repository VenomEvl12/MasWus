using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Model
{
    public class UserModel
    {
        public UserModel()
        {

        }
        public UserModel(string name, string username, string password, int roleId)
        {
            this.Name = name;
            this.Username = username;
            this.Password = password;
            this.RoleId = roleId;
        }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}