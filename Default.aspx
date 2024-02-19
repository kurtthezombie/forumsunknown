<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Testing._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="text-white mt-5">
        <section class="row">
            <div class="col-lg-6 align-content-center">
                <h1 class="text-light big-text fw-bold lh-1 pt-5">GAZE DEEP INTO THE <section class="text-secondary">ABYSS</section></h1>
            </div>
            <div class="col-lg-6 d-flex justify-content-end">
                <img src="Images/alternate.jpg" class="img-fluid" alt="Alternate Image" width="400" height="auto">
            </div>
        </section>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1>ForumsUnknown</h1>
            <p class="lead">ForumsUnknown is a forum site offering a platform for users to share and discuss unusual, eerie, and mysterious topics.</p>
            <p><a runat="server" href="~/About" class="btn btn-dark btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Lorem ipsum</h2>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Sed ac metus sit amet risus facilisis vestibulum. 
                    Mauris nec diam nec quam placerat finibus.
                </p>
                <p>
                    <a class="btn btn-outline-light" runat="server" href="~/About">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Lorem ipsum dolor</h2>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Sed ac metus sit amet risus facilisis vestibulum. 
                </p>
                <p>
                    <a class="btn btn-outline-light" runat="server" href="~/About">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Lorem ipsum dolor sit amet</h2>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Sed ac metus sit amet risus facilisis vestibulum. 
                </p>
                <p>
                    <a class="btn btn-outline-light" runat="server" href="~/About">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
