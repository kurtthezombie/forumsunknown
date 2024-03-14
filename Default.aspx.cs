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

                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in dtPosts.Rows)
                {
                    string title = dr["Title"].ToString();
                    string content = dr["Content"].ToString();
                    string createdAt = dr["CreatedAt"].ToString();
                    string author = dr["Author"].ToString();

                    sb.Append("<div class='container bg-transparent'>");
                    sb.Append("  <div class='card p-5 bg-transparent col-lg-5 border-light mx-auto'>");
                    sb.Append("     <div class='card-header border-light'>");
                    sb.Append("         <div class='card-title display-5 fw-normal'>" + title + "</div>");
                    sb.Append("         <div class='card-subtitle'>by " + author + "</div>");
                    sb.Append("     </div>");
                    sb.Append("    <div class='card-body'>" + content + "</div>");
                    sb.Append("    <div class='card-footer'>Posted on: " + createdAt + "</div>");
                    sb.Append("  </div>");
                    sb.Append("</div>");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("<br />");
                }
                mainContent2.InnerHtml = sb.ToString();
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
                            INNER JOIN FORUM_USERS FU ON FP.AuthorID = FU.UserID";
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