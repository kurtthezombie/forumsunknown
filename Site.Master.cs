using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                navbarAbout.Visible = false;
                navbarContact.Visible = false;
                loginItem.Visible = false;
                registerItem.Visible = false;
                createPostBtn.Visible = true;
                welcomeLink.Visible = true;
                logoutBtn.Visible = true;
                welcomeUsername.InnerText = Session["Username"] as string;
            }
            else
            {
                navbarAbout.Visible = true;
                navbarContact.Visible = true;
                loginItem.Visible = true;
                registerItem.Visible = true;
                createPostBtn.Visible = false;
                welcomeLink.Visible = false;
                logoutBtn.Visible = false;
            }
        }
        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            //unset session
            Session.Clear();
            //go to some page
            Response.Redirect("Login.aspx");
        }
        
        protected void BtnCreatePost_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreatePost.aspx");
        }
    }
}