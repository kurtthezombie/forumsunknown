using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
namespace Testing
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                mainContent1.Visible = false;
                mainContent2.Visible = true;

                DataTable dtPosts = GetForumPostsFromDatabase();

                if (dtPosts.Rows.Count > 0)
                {
                    ForumPostsRepeater.DataSource = dtPosts;
                    ForumPostsRepeater.DataBind();
                    EmptyPostMsg.Visible = false;
                }
                else
                {
                    EmptyPostMsg.Visible = true;
                }
            }
            else
            {
                mainContent1.Visible = true;
                mainContent2.Visible = false;
            }
        }
        private DataTable GetForumPostsFromDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string query = @"SELECT FP.Title, FP.Content, FP.CreatedAt, FU.Username as Author
                            FROM FORUM_POSTS FP
                            INNER JOIN FORUM_USERS FU ON FP.AuthorID = FU.UserID
                            ORDER BY CreatedAt DESC";
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
    }
}