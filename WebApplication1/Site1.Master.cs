using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication1;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private string strConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else if (!IsPostBack)
            {
                GetMenuAccess();
            }
        }

        private void GetMenuAccess()
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetAccessMenu";
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Session["userid"];
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];

                DataRow[] drowpar = dt.Select();

                int inc = 0;

                foreach (DataRow dr in drowpar)
                {
                    Menu1.Items.Add(new MenuItem(dr["Tittle"].ToString(),
                    dr["IdMenuAccess"].ToString(),
                    dr["MenuAddress"].ToString(),
                    dr["MenuAddress"].ToString()));
                    inc++;
                }

                con.Close();
                if (drowpar.Length == 0) PanelControl.Visible = false;
            }
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Logout.aspx");
        }
    }
}