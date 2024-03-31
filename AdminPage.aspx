<%@ Page Title="Admin Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Testing.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="display-6 text-white"><%: Page.Title %></h2>
    <br />
    <asp:Button ID="BtnUsers" runat="server" Text="Users" CssClass="btn btn-outline-light" OnClick="BtnUsers_Click"/>
    <asp:Button ID="BtnPosts" runat="server" Text="Posts" CssClass="btn btn-outline-light" OnClick="BtnPosts_Click"/>
    <br />
    <br />
    <asp:Repeater ID="UserRepeater" runat="server">
        <HeaderTemplate>
            <div class="container bg-transparent brawler-regular">
                <table class="table text-light">
                    <thead>
                        <tr>
                            <th scope='col'>ID</th>
                            <th scope='col'>Username</th>
                            <th scope='col'>Email Address</th>
                            <th scope='col'>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("UserID") %></td>
                <td><%# Eval("UserName") %></td>
                <td><%# Eval("EmailAddress") %></td>
                <td>
                    <asp:Button runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="UserEditButton_Click" CommandArgument='<%# Eval("UserID") %>' Visible='<%# Eval("UserName").ToString() != "admin" %>' />
                    <asp:Button runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="UserDeleteButton_Click" CommandArgument='<%# Eval("UserID") %>' Visible='<%# Eval("UserName").ToString() != "admin" %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                    </tbody>
                </table>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <!--POSTS-->
    <asp:Repeater ID="PostRepeater" runat="server">
        <HeaderTemplate>
            <div class="container bg-transparent brawler-regular">
                <table class="table text-light">
                    <thead>
                        <tr>
                            <th scope='col'>ID</th>
                            <th scope='col'>Title</th>
                            <th scope='col'>Content</th>
                            <th scope='col'>Author</th>
                            <th scope='col'>CreatedAt</th>
                            <th scope='col'>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("PostID") %></td>
                <td><%# Eval("Title") %></td>
                <td><%# Eval("Content") %></td>
                <td><%# Eval("AuthorID") %></td>
                <td><%# Eval("CreatedAt") %></td>
                <td>
                    <asp:Button runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="PostEditButton_Click" CommandArgument='<%# Eval("PostID") %>' />
                    <asp:Button runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="PostDeleteButton_Click" CommandArgument='<%# Eval("PostID") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                    </tbody>
                </table>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
