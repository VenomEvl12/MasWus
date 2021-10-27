<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MasWus.View.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-grid.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/popper.min.js"></script>
    <link href="LoginPage.css" rel="stylesheet" />
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
                    <a href="../Main/Home/HomePage.aspx?category=All">
                        <div class="col-auto">
                            <h3>Home</h3>
                        </div>
                    </a>
                    <div class="col-auto">
                        <a href="../Register/Register.aspx">
                            <h3>Register</h3>
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
                            <div id="input-username">
                                <div class="form-group">
                                    <label>Username</label>
                                    <asp:TextBox CssClass="form-control" ID="LoginUsername" placeholder="username" runat="server"/>
                                </div>
                            </div>
                        </div>
                        <div class="input-control">
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox ID="LoginPassword" placeholder="password" TextMode="Password" CssClass="form-control" runat="server"/>
                            </div>
                        </div>
                        <% if (attempt > 5)
                           { %>
                            <div class="input-control" id="captcha_holder" runat="server">
                                <div class="form-group">
                                     <BotDetect:WebFormsCaptcha ID="LoginCaptcha" runat="server" UserInputID="captcha_input" />
                                    <label style="margin-top: 1vh">Captcha</label>
                                    <asp:TextBox CssClass="form-control" ID="captcha" runat="server"/>
                                </div>
                            </div>
                           <% }%>
                        <% if (login == false)
                           { %>
                        <div class="input-control" id="error-login">
                            username or password incorrect !
                        </div>
                        <% } %>
                        <% if (captchaVal == false)
                           { %>
                        <div class="input-control" id="error-captcha">
                            captcha incorrect !
                        </div>
                        <% } %>
                        <div class="custom-checkbox">
                            <asp:CheckBox ID="remember_me" CssClass="form-check" Text="&nbsp Remember Me" runat="server"/>
                        </div>
                        <div class="button-control">
                            <asp:Button type="submit" CssClass="btn btn-primary" Text="Login" OnClick="BtnLogin" runat="server"/>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
