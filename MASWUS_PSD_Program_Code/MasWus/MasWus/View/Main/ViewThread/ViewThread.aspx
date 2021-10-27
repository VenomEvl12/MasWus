<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main/MainMaster.Master" AutoEventWireup="true" CodeBehind="ViewThread.aspx.cs" Inherits="MasWus.View.Main.ViewThread.ViewThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ViewThread.css" rel="stylesheet" />
    <link href="../../../Content/font-awesome.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../../../Scripts/jquery-3.0.0.js"></script>
    <script src="../../../Scripts/bootstrap.js"></script>
    <script src="../../../Scripts/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid p-0 container">
        <div class="thread-content-container">
            <div class="thread-header">
                <div class="header-name">
                   <%= thread.User.AccountName %>
                </div>
                &nbsp•&nbsp
                <div class="header-category">
                   <%= thread.Category.CategoryName  %>
                </div>
                &nbsp| &nbsp
                <div class="header-time">
                    <%= thread.ThreadDateCreated %>
                </div>
            </div>
            <div class="thread-title">
                <h4><%= thread.ThreadTitle %></h4>
            </div>

            <div class="thread-content">
                <div id="image-carousel" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner">
                        <asp:Repeater ID="repeaterImage" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item <%# (Container.ItemIndex == 0 ? "active" : "") %>">
                                    <img src="<%# Container.DataItem %>" class="d-block w-100 image-e"></img>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <a class="carousel-control-prev" href="#image-carousel" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#image-carousel" role="button" data-slide="next">
                            <span class="carousel-control-next-icon black" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>
                <div>
                    <%= thread.ThreadDescription %>
                </div>
            </div>
            <div class="thread-footer">
                <div class="attributes">
                        <div>
                            <%= thread.ThreadUpVote %> <i class="fa fa-arrow-up" aria-hidden="true"> Up Vote</i> |
                            <i id="black" class="fa fa-eye" aria-hidden="true"> <%= thread.ThreadView %></i>                    
                        </div>
                        <div>
                            <% if (Session["User"] != null)
                                { %>
                            <asp:Button ID="buttonLike" CssClass="btn btn-primary" Text="UpVote" OnClick="buttonLike_Click" runat="server"/>
                            <% } %>
                        </div>
                </div>
            </div>
        </div>
        <div class="thread-reply-container">
            <div class="thread-reply-header">
                <div class="thread-total-counter">
                    <h5><%= totalReplies %> Reply(s)</h5>
                </div>
                <div class="reply-input">
                        <% if (Session["User"] != null) {%>
                    <asp:TextBox ID="replyInput" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Button CssClass="btn btn-primary" Text="reply" runat="server" OnClick="Reply_Click"/>
                        <% } %>
                </div>
            </div>
            <div class="reply-container">
                <asp:Repeater ID="replyRepeater" runat="server">
                    <ItemTemplate>
                        <div class="reply">
                            <div class="reply-header">
                                <%# Eval("User.AccountName") %>
                            </div>
                            <div class="reply-content">
                                <%# Eval("replyDescription") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
