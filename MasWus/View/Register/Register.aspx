<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MasWus.View.Register.Register" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-grid.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/popper.min.js"></script>
    <link href="RegisterPage.css" rel="stylesheet" />
    <script src="RegisterScript.js"></script>
</head>
<body>
    <header id="header">
        <div class="container-fluid">
            <div id="header-content">
                <a href="../Main/Home/HomePage.aspx?category=All">
                    <div class="logo">
                        <img src="../../Assets/MasWus.png" />
                    </div>
                </a>
                <div class="button">
                    <a href="../Main/Home/HomePage.aspx">
                        <div class="col-auto">
                            <h3>Home</h3>
                        </div>
                    </a>
                    <div class="col-auto">
                        <a href="../Login/Login.aspx">
                            <h3>Login</h3>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </header>
    <div id="content">
        <div class="container-fluid">
            <div class="item-center">
                <div class="item-holder">
                    <form runat="server">
                        <div class="logo-holder">
                            <div class="logo">
                                <img src="../../Assets/MasWus.png" />
                            </div>
                        </div>
                        <div class="input-control">
                            <div id="input-accountName">
                                <div class="form-group">
                                    <label>Account Name</label>
                                    <asp:TextBox ID="Name" placeholder="name" CssClass="form-control" runat="server"/>
                                </div>
                            </div>
                        </div>
                        <div class="input-control">
                            <div id="input-username">
                                <div class="form-group">
                                    <label>Username</label>
                                    <asp:TextBox CssClass="form-control" ID="username" placeholder="username" runat="server"/>
                                </div>
                            </div>
                        </div>
                        <div class="input-control">
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox CssClass="form-control" ID="password" TextMode="Password" runat="server"/>
                            </div>
                        </div>
                        <div class="input-control">
                            <BotDetect:WebFormsCaptcha ID="RegisterCaptcha" runat="server" UserInputID="CaptchaRegisterTextBox" />
                            <label>Captcha</label>
                            <asp:TextBox CssClass="form-control" ID="CaptchaRegisterTextBox" runat="server"/>
                        </div>
                        <div class="button-control">
                            <asp:Button ID="btn_submit" CssClass="btn btn-primary" OnClick="BtnRegister" runat="server" Text="Register"/>
                        </div>
                        <div class="input-control">
                            <div id="error_message" visible="false" runat="server">
                                Any Input Must be in right format !
                            </div>
                            <div id="error_captcha" visible="false" runat="server">
                                Captcha is wrong !
                            </div>
                            <div id="error_exists" visible="false" runat="server">
                                username already exist !
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
