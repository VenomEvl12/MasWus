<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main/MainMaster.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MasWus.View.Main.Home.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="HomePage.css" rel="stylesheet" />
    <link href="../../../Content/font-awesome.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="html container-fluid p-0">
        <div class="body">
            <div class="container-hot-thread">
                <h3>HOT THREADS</h3>
                <asp:Repeater ID="repeaterHotThread" runat="server">
                    <ItemTemplate>
                        <a href="../ViewThread/ViewThread.aspx?thread=<%# Eval("threadId") %>" id="redirect-thread">
                            <div class="hot-thread-container" id="<%# Eval("threadId") %>">
                                <div class="hot-header">
                                    <span class="hot-header-name">
                                        <%# Eval("username") %>
                                    </span>
                                    •
                                    <span class="hot-header-category">
                                        <%# Eval("category") %>
                                    </span>
                                </div>
                                <div class="hot-title">
                                    <h5><%# Eval("threadTitle") %></h5>
                                </div>
                                <div class="hot-content">
                                    <image src="<%# Eval("imageUrl") %>"></image>
                                </div>
                                <div class="attribute">
                                    <%# Eval("threadUpVote") %> <i class="fa fa-arrow-up" aria-hidden="true"> Up Vote</i> |
                                    <i class="fa fa-eye" aria-hidden="true"> <%# Eval("threadView") %></i>
                                </div>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="container-thread-list">
                <h3>THREAD LIST</h3>
                <asp:Repeater ID="repeaterThread" runat="server">
                    <ItemTemplate>
                        <a href="../ViewThread/ViewThread.aspx?thread=<%# Eval("threadId") %>" id="redirect-thread">
                            <div class="thread-container" id="<%# Eval("threadId") %>">
                                <div class="thread-header">
                                    <span>
                                     <%# Eval("User.AccountName") %>
                                    </span>
                                    •
                                    <span>
                                        <%# Eval("Category.CategoryName")%>
                                    </span>
                                </div>
                                <div class="thread-title">
                                    <h5><%# Eval("ThreadTitle") %></h5>
                                </div>
                                <div class="thread-content">
                                    <%# Eval("ThreadDescription") %>
                                </div>
                                <div class="attribute">
                                     <%# Eval("ThreadUpVote") %> <i class="fa fa-arrow-up" aria-hidden="true"> Up Vote</i> |
                                    <i class="fa fa-eye" aria-hidden="true"> <%# Eval("ThreadView") %></i>
                                </div>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
