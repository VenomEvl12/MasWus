<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main/MainMaster.Master" AutoEventWireup="true" CodeBehind="EditThread.aspx.cs" Inherits="MasWus.View.Main.ManageThread.EditThread.EditThread" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="EditThread.css" rel="stylesheet" />
    <script src="EditThread.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid p-0">
        <div id="container-e">
            <div class="edit-container col-8">
                <div class="edit-container-margin">
                    <div class="edit-container-title">
                        <div class="edit-label">
                            <h3>Title</h3>
                        </div>
                        <div class="edit-title-input">
                            <asp:TextBox ID="threadTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="edit-container-description">
                        <div class="edit-label">
                            <h3>Description</h3>
                        </div>
                        <div class="edit-description-input">
                            <asp:TextBox ID="threadDescription" TextMode="MultiLine" CssClass="form-control description-input" Rows="15" runat="server"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="edit-container-category">
                        <div class="edit-label">
                            <h3>Category</h3>
                        </div>
                        <div class="edit-category-input">
                            <asp:DropDownList ID="threadCategory" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Game" Value="Game"></asp:ListItem>
                                <asp:ListItem Text="Tech" Value="Tech"></asp:ListItem>
                                <asp:ListItem Text="Animal" Value="Animal"></asp:ListItem>
                                <asp:ListItem Text="Otomotive" Value="Otomotive"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="button-submit">
                        <asp:Button CssClass="btn btn-primary btn-submit" Text="Submit" OnClick="btnUpdate_Click" runat="server"/>
                        <asp:Button CssClass="btn btn-danger btn-submit" Text="Delete" OnClick="btnDelete_Click" runat="server"/>
                    </div>
                    <div class="edit-container-image">
                        <div class="edit-label">
                            <h3>Image</h3>
                        </div>
                        <asp:Repeater ID="repeaterImage" runat="server">
                            <ItemTemplate>
                                <div class="image-container">
                                    <asp:Image ImageUrl="<%# Container.DataItem %>" CssClass="image-size" runat="server"/>
                                    <asp:Button ID="btnDelete" CommandName="<%# Container.ItemIndex %>" CssClass="btn btn-primary button-delete" OnCommand="btnDelete_Command" Text="Delete" runat="server"/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="thread-list-container col-4">
                <div class="thread-list-margin">
                    <asp:Repeater ID="thread_repeater" runat="server">
                        <ItemTemplate>
                            <div class="thread-container-margin">
                                <div class="shadow">
                                    <div class="thread-container" id="<%# Eval("ThreadId") %>" onclick="ThreadClicked(id);return false;">
                                        <%# DataBinder.Eval(Container.DataItem, "ThreadTitle") %>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="threadEditValue" Value="" ClientIDMode="Static" runat="server"/>
                    <asp:Button ID="btnThreadClick" style="display: none" ClientIDMode="Static" runat="server" OnClick="BtnThread_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
