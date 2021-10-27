using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using MasWus.Utility;

namespace MasWus.View.Main
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] == null)
            {
                if(Request.Cookies["auth_user"] != null)
                {
                    User user = (User) (new JavaScriptSerializer().Deserialize(Request.Cookies["auth_user"].Value, typeof(User)));
                    Session.Add("User", user);
                }
            }
        }

        protected void BtnLogout(object sender, EventArgs e)
        {
            Session.Remove("User");
            if(Request.Cookies["auth_user"] != null)
            {
                Response.Cookies.Clear();
            }
            Session.Abandon();
            Response.Redirect("/View/Main/Home/HomePage.aspx");
        }
    }
}