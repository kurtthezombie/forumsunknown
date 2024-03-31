using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing
{
    public partial class CreatePost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Username"] != null))
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            //conn string
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //the data
            string title = TxtTitle.Text;
            string content = TxtContent.Text;
            string username = Session["Username"].ToString();
            //query
            string query = "INSERT INTO FORUM_POSTS (Title, Content, CreatedAt, AuthorID) " +
                "VALUES (@Title, @Content, GETDATE(), (SELECT UserID FROM FORUM_USERS WHERE UserName = @Username))";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Content", content);
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        LblCreatePostMsg.Text = "Post created.";
                        LblCreatePostMsg.ForeColor = Color.Green;
                        TxtTitle.Text = "";
                        TxtContent.Text = "";
                    }
                    catch (SqlException ex)
                    {
                        Response.Write("An error occurred: " + ex.Message);
                    }
                }
            }

        }
    }
}