<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Testing.Register" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="text-white mt-5">
        <!--REGISTRATION CARD-->
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-5">
                    <div class="card border-1 bg-transparent p-5">
                        <div class="card-header display-6 brawler-regular">
                            <%: Title %>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Label">Username</asp:Label>
                                <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control bg-transparent text-white border-0 border-bottom rounded-0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsername" ControlToValidate="TxtUsername" runat="server" ErrorMessage="Field Required!" ForeColor="red"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvTxtUsername" ControlToValidate="TxtUsername" runat="server" ErrorMessage="Username already exists!" ForeColor="red"></asp:CustomValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Label">Email Address</asp:Label>
                                <asp:TextBox ID="TxtEmailAdd" runat="server" TextMode="Email" CssClass="form-control bg-transparent text-white border-0 border-bottom rounded-0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmailAdd" ControlToValidate="TxtEmailAdd" runat="server" ErrorMessage="Field Required!" ForeColor="red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="Label">Password</asp:Label>
                                <asp:TextBox ID="TxtPass" runat="server" TextMode="Password" CssClass="form-control bg-transparent text-white border-0 border-bottom rounded-0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Field Required!" ControlToValidate="TxtPass" ForeColor="red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" Text="Label">Confirm Password</asp:Label>
                                <asp:TextBox ID="TxtConfirmPass" runat="server" TextMode="Password" CssClass="form-control bg-transparent text-white border-0 border-bottom rounded-0"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvConfirmPass" runat="server" ErrorMessage="Field Required!" ControlToValidate="TxtConfirmPass" ForeColor="red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cmpvConfirmPass" runat="server" ErrorMessage="Passwords do not match!" ControlToValidate="TxtConfirmPass" ControlToCompare="TxtPass" Operator="Equal" ForeColor="red"></asp:CompareValidator>
                            </div>
                            <asp:Label ID="LblRegisterMsg" runat="server" Text="" CssClass="text-success"></asp:Label>
                            <!--BUTTONS FOR SUBMISSION-->
                            <div class="form-group">
                                <div class="d-flex justify-content-center">
                                    <asp:Button ID="BtnRegister" runat="server" Text="Signup" OnClick="BtnRegister_Click" OnClientClick="return confirmRegistration();" CssClass="btn btn-dark rounded-0 w-100" />
                                </div>
                                <br />
                                <div class="d-flex justify-content-center">
                                    <p>
                                        Already have an account?
                                        <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="~/Login.aspx" CssClass="text-white fw-bold">Login</asp:HyperLink>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script>
            function confirmRegistration() {
                // Display confirmation dialog
                return confirm('Are you sure you want to create this account?');
            }
        </script>
    </main>
</asp:Content>
