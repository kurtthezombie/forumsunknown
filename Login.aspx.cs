using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            LblLoginMsg.Text = string.Empty;

            if (Page.IsValid)
            {
                string username = TxtUsername.Text;
                string password = TxtPassword.Text;

                bool userExists = CheckUsernameExists(username);

                if (userExists)
                {
                    if (checkCredentials(username,password))
                    {
                        LblLoginMsg.Text = "Successfully logged in!";
                    }
                    else
                    {
                        LblLoginMsg.Text = "Incorrect username or password";
                    }
                }
                else
                {
                    LblLoginMsg.Text = "Account does not exist";
                }
            }
            

        }

        private bool checkCredentials(string username,string password)
        {
            string connectionString = "Data Source=LAPTOP-U9VDBFCE;Initial Catalog=ForumsUnknown;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string query = "SELECT COUNT(*) FROM FORUM_USERS WHERE Username = @UserName AND UserPassword = @Password ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private bool CheckUsernameExists(string username)
        {
            string connString = "Data Source=LAPTOP-U9VDBFCE;Initial Catalog=ForumsUnknown;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string query = "SELECT COUNT(*) FROM FORUM_USERS WHERE UserName = @Username";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    connection.Open();

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }
    }
}