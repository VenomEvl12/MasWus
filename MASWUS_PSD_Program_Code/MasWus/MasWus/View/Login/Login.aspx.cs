using MasWus.Handler;
using MasWus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace MasWus.View.Login
{
    public partial class Login : System.Web.UI.Page
    {
        public int attempt = 0;
        public bool login = true;
        public bool captchaVal = true;
        User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] != null)
            {
                Response.Redirect("/View/Main/Home/HomePage.aspx?category=All");
            }
            TheadSingelton.GetInsntance().SaveThreadID(0);
            attempt = CheckLoginAttemptSingelton.GetInstance().GetAttemptTotal();
        }

        protected void BtnLogin(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(LoginUsername.Text);
            System.Diagnostics.Debug.WriteLine(LoginPassword.Text);
            if (string.IsNullOrEmpty(LoginUsername.Text) || string.IsNullOrEmpty(LoginPassword.Text))
            {
                CheckLoginAttemptSingelton.GetInstance().IncreaseAttempt();
                attempt = CheckLoginAttemptSingelton.GetInstance().GetAttemptTotal();
                login = false;
                captchaVal = true;
                return;
            }
            user = UserHandler.GetUserData(LoginUsername.Text.ToLower(), HashFunction.Sha256(LoginPassword.Text));
            if (user == null)
            {
                CheckLoginAttemptSingelton.GetInstance().IncreaseAttempt();
                attempt = CheckLoginAttemptSingelton.GetInstance().GetAttemptTotal();
                login = false;
                captchaVal = true;
                return;
            }
            else
            {   
                if (attempt > 5)
                {
                    bool isHuman = LoginCaptcha.Validate(captcha.Text);
                    captcha.Text = null;
                    if (!isHuman)
                    {
                        captchaVal = false;
                        login = true;
                        return;
                    }
                }
                attempt = 0;
                CheckLoginAttemptSingelton.GetInstance().ResetToZero();
                Session.Add("User", user);
                if (remember_me.Checked)
                {
                    string json = new JavaScriptSerializer().Serialize(user);
                    HttpCookie cookie = new HttpCookie("auth_user", json);
                    cookie.Expires = DateTime.Now.AddHours(2.0);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("../Main/Home/HomePage.aspx");
            }
        }

    }
}