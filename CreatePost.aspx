<%@ Page Title="Create Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="Testing.CreatePost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="card col-lg-5 border-light mx-auto bg-transparent p-3">
            <div class="card-header display-6 text-light border-0">Create Post</div>
            
            <div class="card-body">
                <div class="form-group text-light">
                    <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
                    <asp:TextBox ID="TxtTitle" CssClass="form-control border-bottom rounded-0 text-light border-0 bg-transparent" TextMode="SingleLine" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RfvTxtTitle" ControlToValidate="TxtTitle" runat="server" ErrorMessage="Title is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <br />
                <div class="form-group text-light">
                    <asp:Label ID="lblContent" runat="server" Text="Content"></asp:Label>
                    <asp:TextBox ID="TxtContent" CssClass="form-control text-light bg-transparent" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                <asp:Label ID="LblCreatePostMsg" runat="server" Text=""></asp:Label>
                <br />
                <div class="form-group text-light">
                    <asp:Button ID="btnPost" CssClass="btn btn-outline-light w-100" runat="server" Text="Post" OnClick="btnPost_Click"/>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
