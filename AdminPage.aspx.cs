using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing
{
    public partial class AdminPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Username"].ToString() != "admin")
            {
                UserRepeater.Visible = false;
                PostRepeater.Visible = false;
                Response.Redirect("Login.aspx");
            }
        }
        protected void BtnUsers_Click (object sender, EventArgs e)
        {
            DataTable dtUsers = GetForumUsersFromDatabase();
            UserRepeater.DataSource = dtUsers;
            UserRepeater.DataBind();

            UserRepeater.Visible = true;
            PostRepeater.Visible = false;

        }

        protected void BtnPosts_Click(object sender, EventArgs e)
        {
            DataTable dtUsers = GetForumPostsFromDatabase();
            PostRepeater.DataSource = dtUsers;
            PostRepeater.DataBind();

            UserRepeater.Visible = false;
            PostRepeater.Visible = true;
        }

        private DataTable GetForumPostsFromDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string query = @"SELECT PostID, Title, Content, AuthorID, CreatedAt FROM FORUM_POSTS";
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        private DataTable GetForumUsersFromDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string query = @"SELECT UserID, UserName, EmailAddress FROM FORUM_USERS";
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        protected void UserEditButton_Click(object sender, EventArgs e)
        {

        }
        protected void FakeBtnUsersClick(string btnName)
        {
            object sender = null;
            EventArgs e = EventArgs.Empty;
            if (btnName == "users")
            {
                BtnUsers_Click(sender, e);
            }
            else
            {
                BtnPosts_Click(sender, e);
            }
        }

        protected void UserDeleteButton_Click(Object sender, EventArgs e)
        {
            Button button = (Button)sender;

            int id = Convert.ToInt32(button.CommandArgument);

            if (id != 1)
            {
                bool UserDeleted = DeleteUserById(id);

                if (UserDeleted)
                {
                    FakeBtnUsersClick("users");
                }
                else
                {
                    //display failed to delete user
                }
            }
            else
            {
                //Display message that admin cant be deleted
            }
        }

        private bool DeleteUserById(int id)
        {
            bool postsDeleted = DeletePostByAuthor(id);
            if (postsDeleted)
            {
                string connectionString = "Data Source=LAPTOP-U9VDBFCE;Initial Catalog=ForumsUnknown;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                string sqlDelete = "DELETE FROM FORUM_USERS WHERE UserID = @UserId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", id);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            else
            {
                return false;
            }
            
        }

        private bool DeletePostByAuthor(int id)
        {
            string connectionString = "Data Source=LAPTOP-U9VDBFCE;Initial Catalog=ForumsUnknown;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            string sqlDelete = "DELETE FROM FORUM_POSTS WHERE AuthorID = @UserId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlDelete, connection))
                {
                    command.Parameters.AddWithValue("@UserId", id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        protected void PostEditButton_Click(object sender, EventArgs e)
        {

        }

        protected void PostDeleteButton_Click(Object sender, EventArgs e)
        {

        }
    }
}