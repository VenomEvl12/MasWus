
using MasWus.Handler;
using MasWus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasWus.View.Register
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("/View/Main/Home/HomePage.aspx?category=All");
            }
            if (!IsPostBack)
            {
               
            }
            TheadSingelton.GetInsntance().SaveThreadID(0);
        }

        protected void BtnRegister(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(Name.Text) || Name.Text.Contains(" ") || Name.Text.Length <= 5 || Name.Text.Length >= 20)
            {
                error_message.Visible = true;
                error_captcha.Visible = false;
                error_exists.Visible = false;
                return;
            }
            if (string.IsNullOrEmpty(username.Text) || username.Text.Contains(" ") || username.Text.Length <= 5 || username.Text.Length >= 20 || UserHandler.SelectUsername(username.Text.ToLower()))
            {
                error_message.Visible = false;
                error_captcha.Visible = false;
                error_exists.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(password.Text) || password.Text.Contains(" ") || password.Text.Length <= 5 || password.Text.Length >= 20 || password.Text.Contains(" ") || !InputValidation.IsAlphaNumeric(password.Text))
            {
                error_message.Visible = true;
                error_captcha.Visible = false;
                error_exists.Visible = false;
                return;
            }
            bool isHuman = RegisterCaptcha.Validate(CaptchaRegisterTextBox.Text);
            System.Diagnostics.Debug.WriteLine(isHuman);
            CaptchaRegisterTextBox.Text = null;
            if (!isHuman)
            {
                error_message.Visible = false;
                error_captcha.Visible = true;
                error_exists.Visible = false;
            }
            else
            {
                
                UserHandler.InsertModel(new Model.UserModel(Name.Text, username.Text.ToLower(), HashFunction.Sha256(password.Text), 2));
                Response.Redirect("../Login/Login.aspx");
            }
        }
    }
}