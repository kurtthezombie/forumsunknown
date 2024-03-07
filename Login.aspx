<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Testing.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="text-white mt-5">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-5">
                    <div class="card p-5 bg-transparent">
                        <div class="card-header display-6 brawler-regular"><%: Title %></div>
                        <div class="card-body">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Label">Username</asp:Label>
                                <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control bg-transparent text-white border-0 border-bottom rounded-0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsername" ControlToValidate="TxtUsername" runat="server" ErrorMessage="Field Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Label">Password</asp:Label>
                                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control bg-transparent text-white border-0 border-bottom rounded-0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="TxtPassword" runat="server" ErrorMessage="Field Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <asp:Label ID="LblLoginMsg" runat="server" Text=""></asp:Label>
                            <div class="form-group">
                                <div class="d-flex justify-content-center">
                                    <br />
                                    <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="btn btn-dark w-100" OnClick="BtnLogin_Click" />
                                </div>
                                <br />
                                <div class="d-flex justify-content-center">
                                    <p>Don't have an account yet?
                                        <asp:HyperLink ID="hlRegister" NavigateUrl="~/Register.aspx" runat="server" CssClass="text-white fw-bold">Signup</asp:HyperLink></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>
    </main>
</asp:Content>
