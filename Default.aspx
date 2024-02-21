﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Testing._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="text-white mt-5">
        <section class="row">
            <div class="col-lg-6 align-content-center">
                <h1 class="text-light big-text fw-bold lh-1 pt-5">GAZE DEEP INTO THE <span class="text-secondary">ABYSS</span></h1>
            </div>
            <div class="col-lg-6 d-flex justify-content-end">
                <img src="Images/alternate.jpg" class="img-fluid" alt="Alternate Image" width="400">
            </div>
        </section>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1>ForumsUnknown</h1>
            <p class="lead">ForumsUnknown is a forum site offering a platform for users to share and discuss unusual, eerie, and mysterious topics.</p>
            <p><a runat="server" href="~/About" class="btn btn-dark">Learn more &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Connect with Like-Minded Explorers</h2>
                <p>
                    Connect with a diverse community of curious minds from around the globe. 
                    Discuss theories, share experiences, and engage in thought-provoking 
                    conversations with others who share your passion for the unknown.
                </p>
                <p>
                    <a class="btn btn-outline-light" runat="server" href="~/About">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Share Your Story</h2>
                <p>
                    Have a chilling tale to tell or a baffling mystery to unravel? 
                    Post it on ForumsUnknown and let our community of investigators 
                    and enthusiasts weigh in. 
                </p>
                <p>
                    <a class="btn btn-outline-light" runat="server" href="~/About">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Join Us Today</h2>
                <p>
                    Embark on a journey into the depths of the unknown. Join ForumsUnknown and become 
                    part of a community dedicated to uncovering the mysteries of our world. 
                </p>
                <p>
                    <a class="btn btn-outline-light" runat="server" href="~/About">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
