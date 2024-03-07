using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;
using Antlr.Runtime.Tree;

namespace Testing
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;

            if (Page.IsValid)
            {
                LblRegisterMsg.Text = string.Empty;
                //check if user exists
                if (UsernameExists(username))
                {
                    cvTxtUsername.IsValid = false;
                }
                else
                {
                    con.Open();
                    string query = "INSERT INTO FORUM_USERS (UserName, EmailAddress, UserPassword)VALUES ('" + TxtUsername.Text + "', '" + TxtEmailAdd.Text + "', '" + TxtPass.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //success message:
                    LblRegisterMsg.Text = "Successfully registered";
                }
            }
        }
        private bool UsernameExists(string username)
        {

            string query = "SELECT COUNT(*) FROM FORUM_USERS WHERE UserName = @Username";
            string connString = "Data Source=LAPTOP-U9VDBFCE;Initial Catalog=ForumsUnknown;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    int count = (int)cmd.ExecuteScalar();

                    connection.Close();
                    return count > 0;
                }
            }
        }
    }
}