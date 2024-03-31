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
using Microsoft.AspNet.FriendlyUrls;

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
            string email = TxtEmailAdd.Text;
            string password = TxtPass.Text;

            if (Page.IsValid)
            {
                LblRegisterMsg.Text = string.Empty;
                if (UsernameExists(username))
                {
                    cvTxtUsername.IsValid = false;
                }
                else
                {
                    string connectionString = "Data Source=LAPTOP-U9VDBFCE;Initial Catalog=ForumsUnknown;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

                    using (SqlConnection con = new SqlConnection(connectionString)) {
                        string query = "INSERT INTO FORUM_USERS (UserName, EmailAddress, UserPassword)VALUES (@UserName, @EmailAddress, @UserPassword)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@UserName", username);
                            cmd.Parameters.AddWithValue("@EmailAddress", email);
                            cmd.Parameters.AddWithValue("@UserPassword", password);

                            try
                            {
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                                //success message:
                                LblRegisterMsg.Text = "Successfully registered";
                            }
                            catch (Exception ex)
                            {
                                // Handle exceptions (e.g., database errors)
                                LblRegisterMsg.Text = "Registration failed: " + ex.Message;
                            }
                        }
                    }

                    //Response.Redirect("Login.aspx");
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