using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        private string strConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (loginUser(txtUsername.Text.Trim(), txtPassword.Text.Trim()) == true)
            {
                Session["userId"] = txtUsername.Text;
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, false);
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invalid Username and/or Password";
            }
        }

        private bool loginUser(string username, string password)
        {
            int ReturnCode2;

            using (SqlConnection con = new SqlConnection(strConString))
            {
                
                SqlCommand cmd = new SqlCommand("spLoginUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUsername = new SqlParameter("@Username", username);
                SqlParameter paramPassword = new SqlParameter("@Password", password);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                con.Close();

                ReturnCode2 = ReturnCode;
            }

            return ReturnCode2 == 1;
        }

        private void GetMenuAccess()
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetAccessMenu";
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUsername.Text.Trim();
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}