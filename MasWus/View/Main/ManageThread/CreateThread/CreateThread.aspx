<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main/MainMaster.Master" AutoEventWireup="true" CodeBehind="CreateThread.aspx.cs" Inherits="MasWus.View.Main.ManageThread.CreateThread.CreateThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CreateThread.css" rel="stylesheet" />
    <script src=<%= ResolveUrl("~/View/Main/ManageThread/CreateThread/CreateThread.js") %>></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid p-0">
        <div id="container">
            <div id="content">
                <div id="input">
                    <div class="content-input">
                        <div class="user">
                            <div>
                                <h5><% Response.Write(user.AccountName); %></h5>
                            </div>
                        </div>
                        <div class="title-input">
                            <div>
                                <asp:TextBox CssClass="form-control" placeholder="title..." ID="threadTitle" runat="server"/>
                            </div>
                        </div>
                        <div class="description-input">
                            <div>
                                <asp:TextBox CssClass="form-control" ID="threadDescription" TextMode="MultiLine" rows="15" placeholder="description" runat="server"/>
                            </div>
                        </div>
                        <div class="upload-image">
                            <div>
                                <asp:FileUpload ID="uploadImage" AllowMultiple="true" runat="server"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="content-choose">
                    <div id="draft">
                        <div class="header">
                            <h3>Draft</h3>
                        </div>
                        <div id="list-draft">
                            <div class="draft-container">
<%--                                <% int x = 0;
                                    foreach (var draft in drafts)
                                    {
                                        string id = "draft" + x;%>
                                <div class="draft-item">
                                    <div class="draft" id="<%= draft.DraftId %>" onclick="DraftClicked(this.id)">
                                        <%= draft.ThreadTitle %>
                                    </div>
                                    <div>
                                        <button type="button" id=<%= id %> class="btn btn-primary" onclick="deleteDraftClicked(this.id)">Delete</button>
                                    </div>
                                </div>
                                <% x++;
                                    } %>
                                <asp:Button ID="deleteClick" OnClick="Delete_Click" style="display: none;" ClientIDMode="Static" runat="server"/>
                                <asp:HiddenField ID="HiddenValueDelete" ClientIDMode="Static" runat="server"/>--%>
                                <asp:Repeater ID="draftRepeater" runat="server">
                                    <ItemTemplate>
                                        <div class="draft-item">
                                            <div class="draft" id="<%# Eval("DraftId") %>" onclick="DraftClicked(this.id)">
                                                <%# Eval("ThreadTitle") %>
                                            </div>
                                            <div>
                                                <asp:Button Text="Delete" ID="btnDelete" CssClass="btn btn-primary" UseSubmitBehavior="false" CommandName="<%# Container.ItemIndex %>" OnCommand="btnDelete_Command" runat="server"/>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Button ID="draftClick" style="display: none;" OnClick="Draft_Click" ClientIDMode="Static" runat="server"/>
                                <asp:HiddenField ID="hiddenValue" Value="" ClientIDMode="Static" runat="server"/>
                            </div>
                        </div>
                    </div>
                    <div id="submit-container">
                        <div class="category-menu">
                            <div class="header-category">
                                Choose Category
                            </div>
                            <div class="category-choose">
                                <asp:DropDownList ID="category" CssClass="custom-select" runat="server">
                                    <asp:ListItem Value="Game">Game</asp:ListItem>
                                    <asp:ListItem Value="Tech">Tech</asp:ListItem>
                                    <asp:ListItem Value="Animal">Animal</asp:ListItem>
                                    <asp:ListItem Value="Otomotive">Otomotive</asp:ListItem>
                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>'
                        <div class="button-choose">
                            <asp:Button ID="saveDraft" CssClass="btn btn-outline-primary" runat="server" OnClick="SaveDraft_Click" Text="Save Draft"/>
                            <asp:Button ID="post" class="btn btn-primary post" Text="Post" OnClick="Post_Click" runat="server"/>
                        </div>
                        <% if (errorMessage)
                            { %>
                        <div class="error-message">
                            title or description must be filled !
                        </div>
                        <% }
                            if (errorFile) {%>
                        <div class="error-message">
                            file must be .jpg, .png, or .jpeg !
                        </div>
                        <% } %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
